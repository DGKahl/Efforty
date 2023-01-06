using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using System.Data;

namespace Efforty
{
    class sqladapter
    {
        //ConnectionString
        private static string LoadConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }


        //// AUFGABEN (TASKS) //////////////////////////////////////////////////////////////////////////////////////

        //Alle Aufgaben für Startbild laden
        public List<string> GetTasks()
        {
            List<string> list = new List<string>();

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                cnn.Open();

                com.CommandText = "SELECT tasks.name AS name FROM tasks";
                SQLiteDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(reader["name"].ToString());
                }
                reader.Close();
                cnn.Close();
            }
            return list;
        }

        //Hole Namen einer Task anhand der ID
        public string GetSelectedTaskName(int id)
        {
            string taskname = "";
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                cnn.Open();

                com.CommandText = "SELECT name AS name FROM tasks WHERE id = '" + id + "';";
                SQLiteDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    taskname = reader["name"].ToString();
                }
                reader.Close();
                cnn.Close();
            }
            return taskname;
        }

        //Hole ID einer Task anhand des Namens
        public int GetSelectedTaskID(string taskname)
        {
            int id = 0;
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                cnn.Open();

                com.CommandText = "SELECT ID AS id FROM tasks WHERE name = '" + taskname + "';";
                SQLiteDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    id = Int32.Parse(reader["id"].ToString());
                }
                reader.Close();
                cnn.Close();
            }
            return id;
        }

        //Hole Activity-ID einer gewählten Task anhand des Tasknamens
        public int GetActivityIDfromTask(string taskname)
        {
            int activityID = 0;

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                cnn.Open();

                com.CommandText = "SELECT ActivityID AS activityid FROM tasks WHERE name = '" + taskname + "';";
                SQLiteDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    activityID = Int32.Parse(reader["activityid"].ToString());
                }
                reader.Close();
                cnn.Close();
            }
            return activityID;
        }

        //Hole Activity-Name einer gewählten Task anhand des Tasknamens
        public string GetActivityNamefromTask(string taskname)
        {
            int activityID = 0;
            string activityname = "";

            //-1- Hole ID der Activity basierend auf Taskname
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                cnn.Open();

                com.CommandText = "SELECT ActivityID AS activityid FROM tasks WHERE name = '" + taskname + "';";
                SQLiteDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    activityID = Int32.Parse(reader["activityid"].ToString());
                }
                reader.Close();
                cnn.Close();
            }

            //-2- Hole ActivityName basierend auf ID aus -1-
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                cnn.Open();

                com.CommandText = "SELECT name AS name FROM activities WHERE id = '" + activityID + "';";
                SQLiteDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    activityname = (reader["name"].ToString());
                }
                reader.Close();
                cnn.Close();
            }
            return activityname;
        }

        //Hole aktuelle Zeit der Task (relevant für "Pause")
        public string GetCurrentDuration(int TaskID)
        {
            string duration = "";

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                cnn.Open();

                com.CommandText = "SELECT elapsed AS elapsed FROM tasks WHERE ID = '" + TaskID + "';";
                SQLiteDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    duration = reader["elapsed"].ToString();
                }
                reader.Close();
                cnn.Close();
            }
            return duration;
        }


        //Neue Task speichern
        public void SaveTask(string name, string activityname)
        {
            //ID der gewählten Tätigkeit holen
            int activity_id = GetSelectedActivityID(activityname);


            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                com.CommandText = "INSERT INTO tasks (name, ActivityID, elapsed) VALUES ('" + name + "', '" + activity_id + "', '00:00:00')";
                cnn.Open();
                com.ExecuteNonQuery();
                cnn.Close();
            }
        }

        //Task editieren
        public void EditTask(string newname, string oldname, string activityname)
        {
            //ID der gewählten Tätigkeit holen
            int activity_id = GetSelectedActivityID(activityname);

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                com.CommandText = "UPDATE tasks SET Name = '" + newname + "', ActivityID = '" + activity_id + "' WHERE name = '" + oldname + "'";
                cnn.Open();
                com.ExecuteNonQuery();
                cnn.Close();
            }
        }

        //Gewählte Task löschen
        public void DeleteTask(string name)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                com.CommandText = "DELETE FROM tasks WHERE name = '" + name + "'";
                cnn.Open();
                com.ExecuteNonQuery();
                cnn.Close();
            }
        }

        //Taskstatus (pausiert oder nicht) abfragen
        public bool IsPausedTask(int id)
        {
            string result = "";

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                cnn.Open();

                com.CommandText = "SELECT status AS status FROM tasks WHERE ID = '" + id + "';";
                SQLiteDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    result = reader["status"].ToString();
                }
                reader.Close();
                cnn.Close();
            }

            if (result == "paused")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Alles Tasks einer Activity löschen
        public void DeleteTasksofActivity(int i)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                com.CommandText = "DELETE FROM tasks WHERE activityid = '" + i + "'";
                cnn.Open();
                com.ExecuteNonQuery();
                cnn.Close();
            }
        }

        //Alles gespeicherten REsults einer Activity löschen
        public void DeleteResultsofActivity(int i)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                com.CommandText = "DELETE FROM results WHERE activityID = '" + i + "'";
                cnn.Open();
                com.ExecuteNonQuery();
                cnn.Close();
            }
        }

        //Erfasste Zeit speichern
        public void saveduration(timedobject timeobject, string status)
        {
            //Variablen zum temporären Speichern der finalen Task-Informationen
            int finalresult = 0;
            string finalduration = "";
            int finalactivityID = 0;

            //nur Zwischenstand speichern --> in TASK!!!
            //Speichern erfolgt per Addieren auf die vorhandene Zeit, um "pausierte" Tasks korrekt zu aktualisieren:
            updateelapsedtasktime(timeobject);

            if (status == "paused")
            {
                //Abspeichern
                using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    SQLiteCommand com = new SQLiteCommand();
                    com.Connection = cnn;
                    com.CommandText = "UPDATE tasks SET status = 'paused' WHERE id = '" + timeobject.GetID() + "'";
                    cnn.Open();
                    com.ExecuteNonQuery();
                    cnn.Close();
                }

            }
            else if (status == "stopped")
            {
                //Resultat wegspeichern! 2 Schritte:

                ////-1- Hole Daten aus Task DB (tasks)
                using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    SQLiteCommand com = new SQLiteCommand();
                    com.Connection = cnn;
                    cnn.Open();

                    com.CommandText = "SELECT elapsed AS finalduration, result AS finalresult, activityID AS activityID FROM tasks WHERE ID = '" + timeobject.GetID() + "';";
                    SQLiteDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        finalresult = Int32.Parse(reader["finalresult"].ToString());
                        finalduration = reader["finalduration"].ToString();
                        finalactivityID = Int32.Parse(reader["activityID"].ToString());
                    }
                    reader.Close();
                    cnn.Close();
                }

                ////-2- Speichern in DB (results)
                using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    SQLiteCommand com = new SQLiteCommand();
                    com.Connection = cnn;
                    com.CommandText = "INSERT INTO results (duration, activityID, taskname, result) VALUES ('" + finalduration + "', '" + finalactivityID + "', '" + timeobject.GetTaskName() + "', '" + finalresult + "')"; //TODO - check!
                    cnn.Open();
                    com.ExecuteNonQuery();
                    cnn.Close();
                }

                //Löschen der nun abgeschlossenen Task
                DeleteTask(timeobject.GetTaskName());
                //TODO - Man könnte die Task auf "saved" updaten und vor dem Löschen checken, ob der Wert korrekt gesetzt wurde?
            }
            else
            {
                //FEHLER
            }
        }

        //Result bei Beenden einer Task in DB (tasks) speichern
        public void savetaskresult(timedobject timeobj, int result)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                com.CommandText = "UPDATE tasks SET result = '" + result + "'WHERE ID = '" + timeobj.GetID() + "';";
                cnn.Open();
                com.ExecuteNonQuery();
                cnn.Close();
            }
        }

        //Zeiten in "elapsed" einer Task durch Addition aktualisieren. Wurde ausgelagert, da etwas länger und 2x relevant...
        public void updateelapsedtasktime(timedobject timeobj)
        {
            string newelapsedtimevalue = "";

            //Hole alte Zeit
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                cnn.Open();
                com.CommandText = "SELECT elapsed AS elapsed FROM tasks WHERE ID = '" + timeobj.GetID() + "';";
                SQLiteDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    newelapsedtimevalue = reader["elapsed"].ToString();
                }
                reader.Close();
                cnn.Close();
            }

            //Addiere neue Zeit, über "TimeSpan"
            TimeSpan oldtime = TimeSpan.Parse(timeobj.GetDuration());
            TimeSpan newtime = TimeSpan.Parse(newelapsedtimevalue);
            newtime += oldtime;
            newelapsedtimevalue = newtime.ToString(@"hh\:mm\:ss");

            //Speichere summierten, neuen "elapsed" Wert in DB
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                com.CommandText = "UPDATE tasks SET elapsed = '" + newelapsedtimevalue + "'WHERE ID = '" + timeobj.GetID() + "';";
                cnn.Open();
                com.ExecuteNonQuery();
                cnn.Close();
            }
        }


        //// TÄTIGKEITEN (ACTIVITIES) //////////////////////////////////////////////////////////////////////////////////////

        //Lade alle Aktivitäten in eine Liste
        public List<string> GetActivities()
        {
            List<string> list = new List<string>();

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                cnn.Open();

                com.CommandText = "SELECT activities.name AS name FROM activities";
                SQLiteDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(reader["name"].ToString());
                }
                reader.Close();
                cnn.Close();
            }
            return list;
        }

        //Prüfen, ob task schonmal lief (also pausiert ist)
        public bool GetTaskPausedStatus(string taskname)
        {
            string status = "";

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                cnn.Open();

                com.CommandText = "SELECT tasks.status AS status FROM tasks WHERE tasks.name = '" + taskname + "';";
                SQLiteDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    status = reader["status"].ToString();
                }
                reader.Close();
                cnn.Close();
            }

            if (status == "paused")
            {
                return true;
            } else
            {
                return false;
            }
        }


        //Hole Name einer Activity anhand des Namens der Task
        public string GetActivityNameFromTaskName(string taskname)
        {
            string activityname = "";
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                cnn.Open();

                com.CommandText = "SELECT activities.name as activityname FROM activities LEFT JOIN tasks ON tasks.ActivityID = activities.ID WHERE tasks.NAME = '" + taskname + "';";
                SQLiteDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    activityname = reader["activityname"].ToString();
                }
                reader.Close();
                cnn.Close();
            }
            return activityname;
        }



        //Hole ID einer Activity anhand des Namens
        public int GetSelectedActivityID(string activityname)
        {
            int id = 0;
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                cnn.Open();

                com.CommandText = "SELECT ID AS id FROM activities WHERE name = '" + activityname + "';";
                SQLiteDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    id = Int32.Parse(reader["id"].ToString());
                }
                reader.Close();
                cnn.Close();
            }
            return id;
        }


        //Neue Activity speichern - TODO
        public void SaveActivity(int i, string oldname, string newname)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;

                if (i == 1)
                {
                    com.CommandText = "INSERT INTO activities (name) VALUES ('" + newname + "')";
                }
                else
                {
                    com.CommandText = "UPDATE activities SET name = '" + newname + "'WHERE name = '" + oldname + "'";
                }
                cnn.Open();
                com.ExecuteNonQuery();
                cnn.Close();
            }
        }

        //Gewählte Activity löschen
        public void DeleteActivity(string name)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                com.CommandText = "DELETE FROM activities WHERE name = '" + name + "'";
                cnn.Open();
                com.ExecuteNonQuery();
                cnn.Close();
            }
        }


        ///// RESULTS ///////////////////////////////////////////////////////////////////////////////

        //DatagridView befüllen(Fahrer aktiv)
        public DataTable GetCurrentResultsTable()
        {
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteDataReader ReadAll;
                DataTable Tabelle = new DataTable();
                SQLiteCommand com = new SQLiteCommand();
                com.Connection = cnn;
                com.CommandText = "SELECT activities.name AS Aktivität, results.result AS Erledigt, results.duration AS Gesamtdauer FROM results LEFT JOIN activities ON activities.id = results.activityID";
                cnn.Open();
                ReadAll = com.ExecuteReader();
                Tabelle.Load(ReadAll);
                cnn.Close();
                return Tabelle;
            }
        }
    }
}
