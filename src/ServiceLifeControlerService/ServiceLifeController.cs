using System;
using System.Linq;
using System.ServiceProcess;
using System.Timers;
using Models;
using Newtonsoft.Json;
using SharedControllerHelper;
using SharedControllerHelper.Models;

namespace ServiceLifeControllerService
{
    public static class ServiceLifeController
    {
        private static readonly Timer CycleTimer = new Timer();
        public static object SyncObj { get; } = new object();

        public static SettingModel OldSetting { get; private set; } = new SettingModel();
        public static SettingModel NewSetting { get; private set; } = new SettingModel();


        public delegate void ServiceStatusChangedEventHandler(ServiceNotifyEventArgs e);

        public static event ServiceStatusChangedEventHandler ServiceStatusChanged = delegate { };
        public static void OnServiceStatusChanged(ServiceNotifyEventArgs e)
        {
            ServiceStatusChanged?.Invoke(e);
            WindowsEventLog.WriteWarningLog($"The {e.Service.Name} service is {e.NewStatus}!");
        }


        public static void StartLifeCycleController()
        {
            try
            {
                WindowsEventLog.WriteInfoLog($"Services Life Cycle Controller Begin.");

                LoadSettingData();

                ExertSetting();

                CycleTimer.Elapsed += cycleTimer_Elapsed;

                CycleTimer.Start();

                WindowsEventLog.WriteInfoLog($"Services Life Cycle Controller Started.");
            }
            catch (Exception exp)
            {
                WindowsEventLog.WriteErrorLog($"Exception in ServiceLifeController start: {exp.Message}");
            }
        }

        private static void cycleTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            LoadSettingData();
            ExertSetting();

            NotifyStoppedCoveredServices();
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

                // exchange new by old setting
                NewSetting = JsonConvert.DeserializeObject<SettingModel>(settingJson);
            }
            catch (Exception exp)
            {
                WindowsEventLog.WriteErrorLog($"Exception in ServiceLifeController: {exp.Message}");
            }
        }

        private static void ExertSetting()
        {
            CycleTimer.Interval = NewSetting.TimerIntervalMilliseconds;
            CycleTimer.AutoReset = true;
        }

        public static void NotifyStoppedCoveredServices()
        {
            lock (SyncObj)
            {
                var allServices = ServicesHelper.GetAllServices(); // all services
                try
                {
                    foreach (ServiceInfo service in NewSetting.CoveredServices)
                    {
                        // find any new state of covered services
                        var serviceNewStatus =
                            allServices.FirstOrDefault(x => x.Name.Equals(service.Name, StringComparison.CurrentCultureIgnoreCase))?.Status;

                        // find any old state of covered services
                        var serviceOldStatus =
                            OldSetting.CoveredServices.FirstOrDefault(s => s.Name.Equals(service.Name, StringComparison.CurrentCultureIgnoreCase))?.Status;

                        // set new state to new setting service
                        service.Status = serviceNewStatus ?? ServiceControllerStatus.Stopped;

                        // the service stopped just now!!!
                        ServiceControllerStatusChanging newStatus;
                        Enum.TryParse(serviceNewStatus.ToString(), true, out newStatus);

                        // if status changed and identify status changing...
                        if (serviceNewStatus != serviceOldStatus)
                        {
                            if (NewSetting.NotifyJustStatusChangingTo.HasFlag(newStatus))
                            {
                                OnServiceStatusChanged(new ServiceNotifyEventArgs(service, ServiceControllerStatus.Stopped));
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    WindowsEventLog.WriteErrorLog($"Exception in ServiceLifeControllerService: {exp.Message}");
                }
                finally
                {
                    if (allServices != null)
                        GC.SuppressFinalize(allServices);

                    OldSetting = NewSetting;
                }
            }
        }
    }
}
