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
    public partial class TaskEdit : Form
    {
        //zum Aktualisieren der Anzeigen bei erfolgter Speicherung.
        //Timer mytimer = new Timer();

        //Unterscheidung Neuanlage vs. Änderung
        bool changemode; //true: Änderung, keine Neuanlage!

        //"Alter" Name der Aufgabe, im Falle von Änderung:
        string oldname;

        //DELEGATES
        //EVENT UND DELEGATE - Um die gespeicherten Änderungen in der main-Form direkt zu aktualisieren
        public event Formhandler TaskIsSaved;
        public delegate void Formhandler(TaskEdit f, EventArgs e);

        public TaskEdit()
        {
            InitializeComponent();
            changemode = false;
            oldname = "";

            //Dropdown mit Activites füllen
            GetActivities();

            ////initialize Timer_Tick:
            //mytimer.Interval = (2000); // 1 secs
            //mytimer.Tick += new EventHandler(timer_Tick);
        }

        public TaskEdit(string taskname)
        {
            InitializeComponent();
            changemode = true;
            oldname = taskname;
            txtNewTaskName.Text = taskname;

            //Dropdown mit Activities füllen
            GetActivities();

            sqladapter myadapter = new sqladapter();
            cbActivites.SelectedItem = myadapter.GetActivityNamefromTask(taskname);


            ////initialize Timer_Tick:
            //mytimer.Interval = (2000); // 1 secs
            //mytimer.Tick += new EventHandler(timer_Tick);
        }

        //Zweites Argument dient nur zur Unterscheidung, damit "taskname" woanders hingeschrieben wird
        public TaskEdit(string taskname, int identifier)
        {
            InitializeComponent();
            changemode = false;
            oldname = "";

            //Dropdown mit Activities füllen
            GetActivities();

            sqladapter myadapter = new sqladapter();
            cbActivites.SelectedItem = taskname;


            ////initialize Timer_Tick:
            //mytimer.Interval = (2000); // 1 secs
            //mytimer.Tick += new EventHandler(timer_Tick);
        }

        //METHODEN

        //Tätigkeiten holen für Combobox
        public void GetActivities()
        {
            sqladapter myadapter = new sqladapter();
            List<string> myactivities = myadapter.GetActivities();

            foreach (string t in myactivities)
            {
                cbActivites.Items.Add(t);
            }
        }

        ////Methode zum refreshen über den Timer-Tick
        //private void timer_Tick(object sender, EventArgs e)
        //{
        //    lblStatus.Text = "wartend...";
        //    mytimer.Stop();
        //}


        //BUTTONS
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (changemode == false)
            {
                if (txtNewTaskName.Text == "")
                {
                    lblStatus.Text = "Bitte Namen eingeben.";
                    //mytimer.Start();
                }
                else if (cbActivites.SelectedIndex == -1)
                {
                    MessageBox.Show("Bitte Tätigkeit auswählen.", "Fehler", MessageBoxButtons.OK);
                    //mytimer.Start();
                }
                else
                {
                    //(1) Prüfung, ob Eintrag schon in DB vorhanden
                    sqladapter myadapter = new sqladapter();
                    List<string> mytasks = myadapter.GetTasks();

                    if (mytasks.Contains(txtNewTaskName.Text))
                    {
                        lblStatus.Text = "Aufgabe existiert schon.";
                        //mytimer.Start();
                    }
                    else //(2) Falls nein, speichern
                    {
                        myadapter.SaveTask(txtNewTaskName.Text, cbActivites.SelectedItem.ToString());
                        TaskIsSaved(this, e);
                        this.Close();
                        //lblStatus.Text = "Gespeichert!";
                        //mytimer.Start();
                    }
                }
            } else
            {
                sqladapter myadapter = new sqladapter();
                myadapter.EditTask(txtNewTaskName.Text, oldname, cbActivites.SelectedItem.ToString());
                TaskIsSaved(this, e);
                this.Close();
                //TODO: Test Update und Autorefresh in Form1
            }
        }
    }
}
