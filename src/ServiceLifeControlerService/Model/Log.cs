using System;
using System.Diagnostics;

namespace ServiceLifeControllerService.Model
{
    public class Log : ILog
    {
        public string Message { get; set; }
        public string Source { get; set; }
        public string MachineName { get; set; }
        public int EventId { get; set; }
        public EventLogEntryType EntryType { get; set; }
        public DateTime TimeWritten { get; set; }
    }
}
