using System;
using System.Windows.Forms;
using Helper;
using ServiceLifeController.Views;

namespace ServiceLifeController
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WindowsEventLog.EventLogName = Properties.Settings.Default.EventLogName;
            WindowsEventLog.EventLogSourceName = Properties.Settings.Default.EventLogSource;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServicesControllerForm());
        }
    }
}
