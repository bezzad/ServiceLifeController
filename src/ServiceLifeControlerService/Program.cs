using System.ServiceProcess;
using SharedControllerHelper;

namespace ServiceLifeControllerService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            WindowsEventLog.EventLogName = SharedLinks.EventLogName;
            WindowsEventLog.EventLogSourceName = SharedLinks.EventLogSource;
            WindowsEventLog.CreateEventLog();

            var servicesToRun = new ServiceBase[] 
            { 
                new ServiceLifeControllerService() 
            };

            //ServiceBase.Run(servicesToRun);
            servicesToRun.SelectWhatDoing(args);
        }
    }
}
