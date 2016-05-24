﻿using System.ServiceProcess;
using Helper;

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
                new ServiceLifeControllerService() 
            };

            //ServiceBase.Run(servicesToRun);
            servicesToRun.SelectWhatDoing(args);
        }
    }
}