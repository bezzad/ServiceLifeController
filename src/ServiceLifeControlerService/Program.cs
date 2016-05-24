using System.ServiceProcess;

namespace ServiceLifeControllerService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            WindowsEventLog.CreateEventLog();

            var servicesToRun = new ServiceBase[] 
            { 
                new SLCService() 
            };

            //ServiceBase.Run(servicesToRun);
            servicesToRun.SelectWhatDoing(args);
        }
    }
}
