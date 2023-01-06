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
    public partial class ActivityEdit : Form
    {
        public int formstatus;
        public string name;

        //zum Aktualisieren der Anzeigen bei erfolgter Speicherung.
        //Timer mytimer = new Timer();

        //DELEGATES
        //EVENT UND DELEGATE - Um die gespeicherten Änderungen in der main-Form direkt zu aktualisieren
        public event Formhandler ActivityIsSaved;
        public delegate void Formhandler(ActivityEdit f, EventArgs e);

        public ActivityEdit()
        {
            InitializeComponent();

            ////initialize Timer_Tick:
            //mytimer.Interval = (2000); // 1 secs
            //mytimer.Tick += new EventHandler(timer_Tick);
        }

        public ActivityEdit(int i)
        {
            InitializeComponent();
            formstatus = i;

            ////initialize Timer_Tick:
            //mytimer.Interval = (2000); // 1 secs
            //mytimer.Tick += new EventHandler(timer_Tick);

        }

        public ActivityEdit(int i, string name)
        {
            InitializeComponent();
            formstatus = i;
            txtName.Text = name;
            this.name = name;

            ////initialize Timer_Tick:
            //mytimer.Interval = (2000); // 1 secs
            //mytimer.Tick += new EventHandler(timer_Tick);

        }

        ////Methode zum refreshen über den Timer-Tick
        //private void timer_Tick(object sender, EventArgs e)
        //{
        //    lblStatus.Text = "wartend...";
        //    mytimer.Stop();
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check, ob Eintrag schon existiert:
            //Check ob Name schon existiert:
            sqladapter myadaptercheck = new sqladapter();
            List<string> checklist = myadaptercheck.GetActivities();
            if (checklist.Contains(txtName.Text))
            {
                MessageBox.Show("Name existiert bereits.", "Fehler", MessageBoxButtons.OK);
            }
            else
            {
                if (formstatus == 1)
                {
                    //Neuanlage
                    sqladapter myadapter = new sqladapter();
                    myadapter.SaveActivity(formstatus, name, txtName.Text);
                    //ActivityIsSaved(this, e);
                    //lblStatus.Text = "Angelegt!";
                    //mytimer.Start();

                }
                else if (formstatus == 2)
                {
                    //Editieren
                    sqladapter myadapter = new sqladapter();
                    myadapter.SaveActivity(formstatus, name, txtName.Text);
                    //ActivityIsSaved(this, e);
                    //lblStatus.Text = "Änderung gespeichert!";
                    //mytimer.Start();
                }
                else
                {
                    //Fehler

                }
                ActivityIsSaved(this, e);
                this.Close();
            }   
        }
    }
}
