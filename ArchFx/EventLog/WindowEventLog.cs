using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFx.EventLog
{
    public static class WindowEventLog
    {
        public static void WriteLog(string strSourceName, string strMessage, System.Diagnostics.EventLogEntryType enEventLogEntryType)
        {
            System.Diagnostics.EventLog ArchFxLog = new System.Diagnostics.EventLog("ArchFx");

            ArchFxLog.Source = strSourceName;
            ArchFxLog.WriteEntry(strMessage, enEventLogEntryType, 0);
            ArchFxLog.Close();
        }
    }
}
