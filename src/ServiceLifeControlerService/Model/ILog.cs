using System;
using System.Diagnostics;

namespace Model
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
