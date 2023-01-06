using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Efforty
{
    public partial class Form1 : Form
    {
        timedobject timeobject;

        public Form1()
        {
            InitializeComponent();
            FillComboBox();
            FillListBox();
        }

        //METHODEN
        void FillComboBox()
        {
            cbTasks.Items.Clear();
            sqladapter adapter = new sqladapter();
            List<string> list = adapter.GetTasks();
            list.Sort();

            foreach (string t in list)
            {
                cbTasks.Items.Add(t);
            }
            lblSelectedActivity.Text = "keine";
        }

        void FillListBox()
        {
            lbActivities.Items.Clear();
            sqladapter adapter = new sqladapter();
            List<string> list = adapter.GetActivities();
            list.Sort();

            foreach (string t in list)
            {
                lbActivities.Items.Add(t);
            }
        }

        //DELEGATES
        public void Subscriber(TaskEdit f) //Subscriber für Form "TaskEdit"
        {
            f.TaskIsSaved += new TaskEdit.Formhandler(RefreshTaskList);
        }

        public void Subscriber(ActivityEdit f) //Subscriber für Form "ActivityEdit"
        {
            f.ActivityIsSaved += new ActivityEdit.Formhandler(RefreshLbList);
        }

        public void Subscriber(getresults f) //Subscriber für Form "GetResults"
        {
            f.ProcessResults += new getresults.Formhandler(SaveTaskResults);
        }


        // !!! Delegate+Eventhandler in Action!
        public void RefreshTaskList(TaskEdit f, EventArgs e)
        {
            FillComboBox();      
        }

        public void RefreshLbList(ActivityEdit f, EventArgs e)
        {
            FillListBox();
            cbTasks.SelectedIndex = -1;
        }

        public void SaveTaskResults(getresults f, int result)
        {
            sqladapter myadpater = new sqladapter();
            myadpater.savetaskresult(timeobject, result);

        }

        //BUTTONS
        private void btnNewTask_Click(object sender, EventArgs e)
        {
            TaskEdit openform = new TaskEdit();    

            //Subscibing von "main" zur "form", die gerade erstellt wurde!!! <<<<--------- WICHTIG!
            this.Subscriber(openform);
            openform.Show();
        }

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            ActivityEdit openform = new ActivityEdit(1);
            //Subscibing von "main" zur "form", die gerade erstellt wurde!!! <<<<--------- WICHTIG!
            this.Subscriber(openform);
            openform.Show();
            lbActivities.Refresh();
        }

        private void btnChangeActivity_Click(object sender, EventArgs e)
        {
            if (lbActivities.SelectedIndex != -1)
            {
                ActivityEdit openform = new ActivityEdit(2, lbActivities.SelectedItem.ToString());
                //Subscibing von "main" zur "form", die gerade erstellt wurde!!! <<<<--------- WICHTIG!
                this.Subscriber(openform);
                openform.Show();
            }
        }

        private void btnRemoveActivity_Click(object sender, EventArgs e)
        {
            if (lbActivities.SelectedIndex != -1)
            {
                //Messagebox: Warnung über anstehende Löschung
                if (MessageBox.Show("Achtung: Die Tätigkeit, gespeicherte Zeiten und alle zugeordneten Aufgaben werden unwiderruflich gelöscht! Fortfahren?", "Warnung", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //ALLES LÖSCHEN
                    sqladapter adapter = new sqladapter();
                    adapter.DeleteTasksofActivity(adapter.GetSelectedActivityID(lbActivities.SelectedItem.ToString()));
                    adapter.DeleteResultsofActivity(adapter.GetSelectedActivityID(lbActivities.SelectedItem.ToString()));
                    adapter.DeleteActivity(lbActivities.SelectedItem.ToString());
                   
                    //Startbild resetten
                    lbActivities.SelectedIndex = -1;
                    cbTasks.SelectedIndex = -1;
                    FillComboBox();
                    FillListBox();
                }
                else
                {
                    //Abbruch.
                }
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (cbTasks.SelectedIndex != -1)
            {
                sqladapter adapter = new sqladapter();
                adapter.DeleteTask(cbTasks.SelectedItem.ToString());
                FillComboBox();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cbTasks.SelectedIndex != -1)
            {
                //neuer Task, erstmaliges Starten
                timeobject = new timedobject(cbTasks.SelectedItem.ToString());
                timeobject.startTimer();
                btnStart.Enabled = false;
                cbTasks.Enabled = false;
                btnPause.Enabled = true;
                btnEnd.Enabled = true;
                btnNewTask.Enabled = false;
                btnEditTask.Enabled = false;
                btnDeleteTask.Enabled = false;
            }
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            TaskEdit openform = new TaskEdit(cbTasks.SelectedItem.ToString());

            //Subscibing von "main" zur "form", die gerade erstellt wurde!!! <<<<--------- WICHTIG!
            this.Subscriber(openform);
            openform.Show();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            //Zwischenstand speichern; Update "elapsed", "status"
            if (timeobject.runningstatus() == true)
            {
                timeobject.stopTimer();
                sqladapter myadpater = new sqladapter();
                myadpater.saveduration(timeobject, "paused");
                btnStart.Text = "Weiter";
                //cbTasks.SelectedIndex = -1;
            } else
            {
                MessageBox.Show("Gerade läuft nichts.", "Info", MessageBoxButtons.OK);
            }

            //Buttons updaten
            cbTasks.Enabled = true;
            btnStart.Enabled = true;
            btnPause.Enabled = false;
            btnEnd.Enabled = false;
            //cbTasks.SelectedIndex = -1;
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            //check, ob etwas läuft
            if (timeobject.runningstatus() == true)
            {
                //Timer als erstes stoppen, damit User in Ruhe Results eingeben kann
                timeobject.stopTimer();

                //Abfrage der geschafften Einheiten
                getresults openform = new getresults();
                //Subscibing von "main" zur "form", die gerade erstellt wurde!!! <<<<--------- WICHTIG!
                this.Subscriber(openform);
                var dialogResult = openform.ShowDialog();
                //openform.Show();
                //TEST: Result- Wert sollte(?) über event weitergegeben werden?

                sqladapter myadpater = new sqladapter();
                myadpater.saveduration(timeobject, "stopped");
                FillComboBox();

                cbTasks.Enabled = true;
                btnNewTask.Enabled = true;
                btnStart.Enabled = false;
                btnPause.Enabled = false;
                btnEnd.Enabled = false;
                btnEditTask.Enabled = false;
                btnDeleteTask.Enabled = false;
                lblSelectedActivity.Text = "(keine)";

            } else
            {
                MessageBox.Show("Gerade läuft nichts.", "Info", MessageBoxButtons.OK);
            }
        }

        private void cbTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTasks.SelectedIndex == -1)
            {
                btnNewTask.Enabled = true;
                btnStart.Enabled = false;
                btnPause.Enabled = false;
                btnEnd.Enabled = false;
                btnEditTask.Enabled = false;
                btnDeleteTask.Enabled = false;
                lblSelectedActivity.Text = "(keine)";
            } else
            {
                //"Start" oder "Weiter" Button?
                sqladapter myadapter = new sqladapter();
                if (myadapter.GetTaskPausedStatus(cbTasks.SelectedItem.ToString()) == true) {
                    btnStart.Text = "Weiter";
                } else
                {
                    btnStart.Text = "Start";
                }
                btnNewTask.Enabled = true;
                btnStart.Enabled = true;
                btnPause.Enabled = false;
                btnEnd.Enabled = false;
                btnEditTask.Enabled = true;
                btnDeleteTask.Enabled = true;

                //Label mit Namen der zugehörigen Activity füllen
                lblSelectedActivity.Text = myadapter.GetActivityNameFromTaskName(cbTasks.SelectedItem.ToString());
            }
        }

        private void btnShowResults_Click(object sender, EventArgs e)
        {
            Results openform = new Results();
            openform.Show();
        }

        private void lbActivities_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lbActivities.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                TaskEdit openform = new TaskEdit(lbActivities.SelectedItem.ToString(),1);

                //Subscibing von "main" zur "form", die gerade erstellt wurde!!! <<<<--------- WICHTIG!
                this.Subscriber(openform);
                openform.Show();
            }
        }
    }
}
