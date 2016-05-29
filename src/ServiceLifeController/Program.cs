using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;
using ServiceLifeController.Views;
using SharedControllerHelper;

namespace ServiceLifeController
{
    static class Program
    {
        private static readonly string ExePath = Assembly.GetExecutingAssembly().Location;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (!IsAdmin())
            {
                RestartElevated(ExePath, args);
                System.Environment.Exit(1);
            }

            WindowsEventLog.EventLogName = SharedControllerHelper.SharedLinks.EventLogName;
            WindowsEventLog.EventLogSourceName = SharedControllerHelper.SharedLinks.EventLogSource;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServicesControllerForm());
        }

        /// <summary>
        /// Is application running as administrator?
        /// </summary>
        /// <returns>Yes or No?</returns>
        public static bool IsAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();

            return (new WindowsPrincipal(identity)).IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void RestartElevated(string fileName, params string[] args)
        {
            string[] argumentsArray = Environment.GetCommandLineArgs();
            var argumentsLine = string.Empty;

            for (int i = 1; i < argumentsArray.Length; ++i)
                argumentsLine += "\"" + argumentsArray[i] + "\" ";

            ProcessStartInfo info = new ProcessStartInfo
            {
                Arguments = argumentsLine.TrimEnd(),
                FileName = fileName,
                UseShellExecute = true,
                Verb = "runas"
            };
            info.Arguments = string.Join(" ", args);
            info.WorkingDirectory = Path.GetDirectoryName(fileName);

            try
            {
                Process.Start(info);
            }
            catch { return; }

            System.Environment.Exit(1);
        }
    }
}
