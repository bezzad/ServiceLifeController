using System;
using System.Timers;
using Models;
using Newtonsoft.Json;
using SharedControllerHelper;

namespace ServiceLifeControllerService
{
    public static class ServiceLifeController
    {
        private static readonly Timer CycleTimer = new Timer();
        private static SettingModel _setting = new SettingModel();

        public delegate void ServiceStatusChangedEventHandler(ServiceNotifyEventArgs e);
        public static event ServiceStatusChangedEventHandler ServiceStatusChanged;
        public static void OnServiceStatusChanged(ServiceNotifyEventArgs e)
        {
            ServiceStatusChanged?.Invoke(e);
        }



        public static void StartLifeCycleController()
        {
            WindowsEventLog.WriteInfoLog($"Services Life Cycle Controller Begin.");

            LoadSettingData();

            ExertSetting();
            
            CycleTimer.Elapsed += _cycleTimer_Elapsed;

            WindowsEventLog.WriteInfoLog($"Services Life Cycle Controller Started.");
        }

        private static void _cycleTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            LoadSettingData();
            ExertSetting();

            ControllCoveredServices();
        }

        public static void WillBeTurnOff()
        {
            WindowsEventLog.WriteFailureAuditLog($"Server {Environment.MachineName} will be turned off");
            CycleTimer?.Stop();
        }


        private static void LoadSettingData()
        {
            try
            {
                var path = FileManager.DefaultApplicationDataPath;

                var settingJson = FileManager.ReadFileSafely(path);

                if (settingJson == null) return;

                _setting = JsonConvert.DeserializeObject<SettingModel>(settingJson);
            }
            catch (Exception exp)
            {
                WindowsEventLog.WriteErrorLog($"Exception in ServiceLifeController: {exp.Message}");
            }
        }

        private static void ExertSetting()
        {
            CycleTimer.Interval = _setting.TimerIntervalMilliseconds;
            CycleTimer.AutoReset = true;
        }

        public static void ControllCoveredServices()
        {
            
        }
    }
}
