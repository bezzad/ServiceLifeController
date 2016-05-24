using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Helper;

namespace ServiceLifeControllerService
{
    public static class ServiceLifeController
    {
        private static System.Timers.Timer _cycleTimer;

        public static void StartLifeCycleController()
        {
            WindowsEventLog.WriteInfoLog($"Services Life Cycle Controller Begin.");
            _cycleTimer = new Timer()
            {
                AutoReset = true,
                Interval = TimeSpan.FromMinutes(1).TotalMilliseconds
            };
            _cycleTimer.Elapsed += _cycleTimer_Elapsed;

        }

        private static void _cycleTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static void WillBeTurnOff()
        {
            WindowsEventLog.WriteInfoLog($"server will be turned off");
            _cycleTimer?.Stop();
        }
        
    }
}
