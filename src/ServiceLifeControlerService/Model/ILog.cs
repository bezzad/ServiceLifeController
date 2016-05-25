using System;
using System.Diagnostics;

namespace Models
{
    public interface ILog
    {
        string Message { get; set; }
        string Source { get; set; }
        string MachineName { get; set; }
        int EventId { get; set; }
        EventLogEntryType EntryType { get; set; }
        DateTime TimeWritten { get; set; }
    }
}
