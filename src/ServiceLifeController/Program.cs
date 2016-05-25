using System;
using System.Windows.Forms;
using ServiceLifeController.Views;
using SharedControllerHelper;

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
            WindowsEventLog.EventLogName = SharedControllerHelper.SharedLinks.EventLogName;
            WindowsEventLog.EventLogSourceName = SharedControllerHelper.SharedLinks.EventLogSource;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServicesControllerForm());
        }
    }
}
