using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Models;

namespace SharedControllerHelper
{
    public static class WindowsEventLog
    {
        public static string EventLogName { get; set; }
        public static string EventLogSourceName { get; set; }

        #region Methods

        private static void DebuggerWriteLine(string text)
        {
            //Debug.WriteLine(text);
            Trace.WriteLine(text);
        }

        public static void WriteInfoLog(string text)
        {
            WriteInfoLog(text, int.MinValue);
        }
        public static void WriteInfoLog(string text, int eventId)
        {
            if (eventId != int.MinValue)
            {
                EventLog.WriteEntry(EventLogSourceName, text, EventLogEntryType.Information, eventId);
            }
            else
            {
                EventLog.WriteEntry(EventLogSourceName, text, EventLogEntryType.Information);
            }

            DebuggerWriteLine(text);
        }

        public static void WriteErrorLog(string text)
        {
            WriteErrorLog(text, int.MinValue);
        }
        public static void WriteErrorLog(string text, int eventId)
        {
            if (eventId != int.MinValue)
            {
                EventLog.WriteEntry(EventLogSourceName, text, EventLogEntryType.Error, eventId);
            }
            else
            {
                EventLog.WriteEntry(EventLogSourceName, text, EventLogEntryType.Error);
            }

            DebuggerWriteLine(text);
        }

        public static void WriteWarningLog(string text)
        {
            WriteWarningLog(text, int.MinValue);
        }
        public static void WriteWarningLog(string text, int eventId)
        {
            if (eventId != int.MinValue)
            {
                EventLog.WriteEntry(EventLogSourceName, text, EventLogEntryType.Warning, eventId);
            }
            else
            {
                EventLog.WriteEntry(EventLogSourceName, text, EventLogEntryType.Warning);
            }

            DebuggerWriteLine(text);
        }

        public static void WriteFailureAuditLog(string text)
        {
            WriteFailureAuditLog(text, int.MinValue);
        }
        public static void WriteFailureAuditLog(string text, int eventId)
        {
            if (eventId != int.MinValue)
            {
                EventLog.WriteEntry(EventLogSourceName, text, EventLogEntryType.FailureAudit, eventId);
            }
            else
            {
                EventLog.WriteEntry(EventLogSourceName, text, EventLogEntryType.FailureAudit);
            }

            DebuggerWriteLine(text);
        }

        public static void WriteSuccessAuditLog(string text)
        {
            WriteSuccessAuditLog(text, int.MinValue);
        }
        public static void WriteSuccessAuditLog(string text, int eventId)
        {
            if (eventId != int.MinValue)
            {
                EventLog.WriteEntry(EventLogSourceName, text, EventLogEntryType.SuccessAudit, eventId);
            }
            else
            {
                EventLog.WriteEntry(EventLogSourceName, text, EventLogEntryType.SuccessAudit);
            }

            DebuggerWriteLine(text);
        }

        public static void DeleteEventLogFile()
        {
            if (EventLog.Exists(EventLogName))
            {
                // Delete log file
                EventLog.Delete(EventLogName);
            }
        }

        public static void CreateEventLog()
        {
            // Create the source and log, if it does not already exist.
            if (!EventLog.SourceExists(EventLogSourceName))
            {
                EventLog.CreateEventSource(EventLogSourceName, EventLogName);
            }
        }

        public static string GetEventLogName(string source)
        {
            return EventLog.LogNameFromSourceName(source, Environment.MachineName);
        }

        public static void DeleteSource(string source)
        {
            if (EventLog.SourceExists(source, Environment.MachineName))
            {
                EventLog.DeleteEventSource(source, Environment.MachineName); // Delete Source

                using (var elog = new EventLog(EventLogName, Environment.MachineName, source))
                {
                    elog.Clear();
                }
            }
            // recreate
            CreateEventLog();
        }

        public static void DeleteCurrentSource()
        {
            DeleteSource(EventLogSourceName);
        }


        public static IEnumerable<Log> GetEntryCollection()
        {
            var log = new EventLog(EventLogName, Environment.MachineName, EventLogSourceName);

            var logs = (from EventLogEntry entry in log.Entries
                        select new Log
                        {
                            Message = entry.Message,
                            EntryType = entry.EntryType,
#pragma warning disable 618
                            EventId = entry.EventID,
#pragma warning restore 618
                            MachineName = entry.MachineName,
                            Source = entry.Source,
                            TimeWritten = entry.TimeWritten
                        }).ToList();

            return logs;
        }
        public static IEnumerable<Log> GetEntryCollection(bool showErrors, bool showWarnings, bool showInformations, bool showSuccessAudits, bool showFailureAudits)
        {
            IEnumerable<Log> logs = GetEntryCollection();

            if (!showErrors)
                logs = logs.Where(x => x.EntryType != EventLogEntryType.Error).ToList();

            if (!showWarnings)
                logs = logs.Where(x => x.EntryType != EventLogEntryType.Warning).ToList();

            if (!showInformations)
                logs = logs.Where(x => x.EntryType != EventLogEntryType.Information).ToList();

            if (!showSuccessAudits)
                logs = logs.Where(x => x.EntryType != EventLogEntryType.SuccessAudit).ToList();

            if (!showFailureAudits)
                logs = logs.Where(x => x.EntryType != EventLogEntryType.FailureAudit).ToList();

            return logs;
        }
        public static IEnumerable<Log> GetEntryCollection(DateTime from, DateTime to)
        {
            var logs = GetEntryCollection();

            var filteredLogs = logs.Where(x => x.TimeWritten >= @from && x.TimeWritten <= to).ToList();

            return filteredLogs;
        }
        public static IEnumerable<Log> GetEntryCollection(DateTime from, DateTime to, bool showErrors, bool showWarnings, bool showInformations, bool showSuccessAudits, bool showFailureAudits)
        {
            var logs = GetEntryCollection(from, to);

            if (!showErrors)
                logs = logs.Where(x => x.EntryType != EventLogEntryType.Error).ToList();

            if (!showWarnings)
                logs = logs.Where(x => x.EntryType != EventLogEntryType.Warning).ToList();

            if (!showInformations)
                logs = logs.Where(x => x.EntryType != EventLogEntryType.Information).ToList();

            if (!showSuccessAudits)
                logs = logs.Where(x => x.EntryType != EventLogEntryType.SuccessAudit).ToList();

            if (!showFailureAudits)
                logs = logs.Where(x => x.EntryType != EventLogEntryType.FailureAudit).ToList();

            return logs;
        }

        #endregion
    }
}
