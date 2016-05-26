using System;
using System.Collections.Generic;
using System.Reflection;

namespace SharedControllerHelper.Models
{
    public class EmailModel
    {
        public string From { get; set; }
        public string SenderPassword { get; set; }
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string AppName { get; set; } = Assembly.GetCallingAssembly().GetName().Name;
        public string Version { get; set; } = Assembly.GetCallingAssembly().GetName().Version?.ToString();
        public DateTime EmailDateTime { get; set; } = DateTime.Now;
        public string Message { get; set; }
    }
}
