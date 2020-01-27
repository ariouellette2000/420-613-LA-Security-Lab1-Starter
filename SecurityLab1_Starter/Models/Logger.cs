using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace SecurityLab1_Starter.Models
{
    public class Logger
    {
        public void LogToEvent(String message)
        {
            //Log to the event
            //Write the date and the log
            string log = "Application";
            String now = DateTime.Now.ToString();

            EventLog.WriteEntry(log, message + now,
                EventLogEntryType.Warning);

        }

        internal static void Error(Exception exception)
        {
            throw new NotImplementedException();
        }

        public void LogToFile(String message, TextWriter w)
        {
            //Log to the file
            //Write the date and the log
            string log = "Application";
            String now = DateTime.Now.ToString();

            w.Write($"{DateTime.Now.ToLongTimeString()} , {DateTime.Now.ToLongDateString()}"); 
            w.WriteLine(message);
            
            w.Close();

        }
    }
}