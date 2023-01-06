using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efforty
{
    class timedobject
    {
        //Info für DB
        int taskid;
        string taskname;
        string duration;
        int resultcount;
        bool isrunning = false;

        //Zeitdaten
        DateTime start;
        DateTime end;

        public timedobject(string name)
        {
            sqladapter myadapter = new sqladapter();
            taskid = myadapter.GetSelectedTaskID(name);
            //activityid = myadapter.GetActivityIDfromTask(name);
            taskname = myadapter.GetSelectedTaskName(taskid);
        }

        //GETTER / SETTER
        public int GetID() { return taskid; }

        public string GetTaskName() { return taskname; }

        public void startTimer()
        {
            start = DateTime.Now.ToLocalTime();
            isrunning = true;
        }

        public void stopTimer()
        {
            end = DateTime.Now.ToLocalTime();
            isrunning = false;
            duration = end.Subtract(start).ToString(@"hh\:mm\:ss");
        }

        public string GetDuration()
        {
            return duration;
        }

        public void SetDuration(string currentduration)
        {
            duration = currentduration;
        }

        public bool runningstatus()
        {
            return isrunning;
        }

        public void setResults(int results)
        {
            resultcount = results;
        }

        public int GetResults() { return resultcount; }


    }
}
