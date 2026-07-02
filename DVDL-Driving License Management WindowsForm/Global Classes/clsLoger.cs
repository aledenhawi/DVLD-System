using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_Driving_License_Management_WindowsForm.Global_Classes
{
    public static class clsLoger
    {
        private const string _LogName = "DVLD Logs";
        private const string _SourceName = "DVLD";

        static clsLoger()
        {
            Initialize();
        }

        private static void Initialize() 
        {
            try
            {
                if (!EventLog.SourceExists(_SourceName))
                {
                    EventLog.CreateEventSource(_SourceName, _LogName);
                }
            }
            catch (Exception ex)
            {
             Debug.WriteLine($"Logger Init Failed : {ex.Message}");
            }

        }

        public static void LogInfo(string message)
        {
            BuildAndWriteLog(message, EventLogEntryType.Information, null);
        }

        public static void LogWarning(string message)
        {
            BuildAndWriteLog(message, EventLogEntryType.Warning, null);
        }

        public static void LogError(string message, Exception ex = null)
        {
            BuildAndWriteLog(message, EventLogEntryType.Error, ex);
        }

        private static void BuildAndWriteLog(string message, EventLogEntryType type,Exception ex)
        {
            StackTrace trace = new StackTrace(2, true);
            StackFrame frame = trace.GetFrame(0);

            MethodBase method = frame?.GetMethod();

            string className = method?.DeclaringType?.FullName ?? "Unknown";
            string methodName = method?.Name ?? "Unknown";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("==================================");
            sb.AppendLine($"Class : {className}");
            sb.AppendLine($"Method: {methodName}");
            sb.AppendLine($"Message: {message}");

            if (ex != null)
            {
                sb.AppendLine($"Exception : {ex.Message}");
                sb.AppendLine($"StackTrace: {ex.StackTrace}");
            }

            sb.AppendLine("==================================");

            WriteLog(sb.ToString(),type);
        }

        private static void WriteLog(string Message ,EventLogEntryType Type)
        {
            try 
            {
                if (EventLog.SourceExists(_SourceName))
                {
                    EventLog.WriteEntry(_SourceName, Message, Type);
                }
            }
            catch 
            {
                Debug.WriteLine("There where an error while writing log to even log");
            }
        }
    }
}