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
    public partial class Results : Form
    {
        public Results()
        {
            InitializeComponent();

            //Read DB (results)
            sqladapter myadapter = new sqladapter();
            DataTable mytemptable = myadapter.GetCurrentResultsTable();

            //finalen DataTable bauen
            //Finale Ausgabe
            // - je Activity: Aktivity		// 		Summe Erledigtes    //      Gesamtzeit		//      Durchschnitt		--> Ausgabe in HH:MM:SS
            DataTable finaltable = new DataTable("Ergebnisse");
            DataColumn dtColumn;
            DataRow datarow;

            //Aktivität
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Aktivität";
            dtColumn.Caption = "Aktivität";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = true;
            dtColumn.Unique = false;
            finaltable.Columns.Add(dtColumn);

            //Summe Erledigtes
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(double);
            dtColumn.ColumnName = "Erledigtes";
            dtColumn.Caption = "Erledigtes";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = true;
            dtColumn.Unique = false;
            finaltable.Columns.Add(dtColumn);

            //Gesamtzeit
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(TimeSpan);
            dtColumn.ColumnName = "Gesamtzeit";
            dtColumn.Caption = "Gesamtzeit";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = true;
            dtColumn.Unique = false;
            finaltable.Columns.Add(dtColumn);

            //Durchschnitt
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(TimeSpan);
            dtColumn.ColumnName = "Durchschnitt";
            dtColumn.Caption = "Durchschnitt";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = true;
            dtColumn.Unique = false;
            finaltable.Columns.Add(dtColumn);


            //Liste der unique Activities:
            List<string> activities = new List<string>();

            foreach (DataRow dr in mytemptable.Rows)
            {
                if (!activities.Contains(dr["Aktivität"].ToString()))
                {
                    activities.Add(dr["Aktivität"].ToString());
                }
            }

            // Summenbildung
            double summe_erledigtes;
            TimeSpan summe_durations;
            //Durchschnitt errechnen
            TimeSpan durchschnitt_duration;

            //Je Aktivität aus der Liste die Summen und den Durchschnitt berechnen, Zeile daraus bauen und dem finalen Table hinzufügen
            foreach (string s in activities)
            {
                //Werte Nullen für jede Aktivität!
                summe_erledigtes = 0;
                summe_durations = TimeSpan.Parse("00:00:00");


                foreach (DataRow dr in mytemptable.Rows)
                {
                    if (dr["Aktivität"].ToString() == s)
                    {
                        summe_erledigtes += Double.Parse(dr["Erledigt"].ToString());
                        summe_durations += TimeSpan.Parse(dr["Gesamtdauer"].ToString());
                    }
                }

                //TODO - Geht das auch mit Double???
                durchschnitt_duration = new TimeSpan(summe_durations.Ticks / Int32.Parse(summe_erledigtes.ToString()));
                durchschnitt_duration = TimeSpan.Parse(durchschnitt_duration.ToString(@"hh\:mm\:ss"));

                //Alle Ergebnisse für die aktuelle Aktivität als Zeile in finaler Tabelle wegschreiben:             
                datarow = finaltable.NewRow();
                datarow["Aktivität"] = s;
                datarow["Erledigtes"] = summe_erledigtes;
                datarow["Gesamtzeit"] = summe_durations;
                datarow["Durchschnitt"] = durchschnitt_duration;
                finaltable.Rows.Add(datarow);
            }

            //Ausgabe in DatagridView
            dataGridView1.DataSource = finaltable;
        }
    }
}
