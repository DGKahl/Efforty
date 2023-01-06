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
    public partial class getresults : Form
    {
        int result;

        //DELEGATES
        //EVENT UND DELEGATE - Um die gespeicherten Änderungen in der main-Form direkt zu aktualisieren
        public event Formhandler ProcessResults;
        public delegate void Formhandler(getresults f, int result);

        public getresults()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getresults_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TODO - Welche Eingaben sind hier realistisch?
            int num;
            bool isNumber;

            isNumber = Int32.TryParse(textBox1.Text, out num);

            if (textBox1.Text == "" || isNumber == false)
            {
                e.Cancel = true;
                MessageBox.Show("Bitte einen Wert im Zahlenformat eingeben.", "Fehler", MessageBoxButtons.OK);
            }
            else
            {
                result = Int32.Parse(num.ToString());
                ProcessResults(this, result); //TODO - "this" sollte den aktuellen Wert (Eingabe des Users) in Variable "result" enthalten. Prüfen!
            }
        }
    }
}
