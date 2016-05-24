using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;

namespace ServiceLifeControllerService
{
    public static class ServiceLifeController
    {
        public static void StartLifeCycleController()
        {
            WindowsEventLog.WriteInfoLog($"Services Life Cycle Controller Begin.");
        }

        public static void WillBeTurnOff()
        {
            WindowsEventLog.WriteInfoLog($"server will be turned off");
        }
    }
}
