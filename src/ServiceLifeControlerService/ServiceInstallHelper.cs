using System;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.ServiceProcess;
using ServiceProcess.Helpers;
using SharedControllerHelper;

namespace ServiceLifeControllerService
{
    public static class ServiceInstallHelper
    {
        private static readonly string ExePath = Assembly.GetExecutingAssembly().Location;

        public static void SelectWhatDoing(this ServiceBase[] services, string[] args)
        {
            if (!services.Any())
                Environment.Exit(0);

            string serviceName = services[0].ServiceName;

            if (args.Any())
            {
                foreach (string arg in args)
                {
                    switch (arg.ToLower())
                    {
                        case "/d":
                        case "/debug":
                        case "-debug":
                        case "--debug":
                            {
                                if (!IsAdmin())
                                {
                                    RestartElevated(ExePath, args);
                                    System.Environment.Exit(1);
                                }

                                services.LoadServices();
                            }
                            break;

                        case "/i":
                        case "/install":
                        case "-install":
                        case "--install":
                            SafeInstallService(serviceName, args);
                            break;

                        case "/u":
                        case "/uninstall":
                        case "-uninstall":
                        case "--uninstall":
                            SafeUninstallService(serviceName, args);
                            break;

                        default:
                            WindowsEventLog.WriteErrorLog(string.Format(@"\n'{0}' arguments is not defined.", arg));
                            break;
                    }
                }
            }
            else
            {
                if (Environment.UserInteractive) // Install Service
                {
                    WindowsEventLog.WriteInfoLog(string.Format(@"Service executed in UserInteractive mode"));

                    if (!IsAdmin())
                    {
                        WindowsEventLog.WriteInfoLog(string.Format(@"Service go to executed in Run As Admin"));
                        RestartElevated(ExePath, args);
                        System.Environment.Exit(1);
                    }

                    WindowsEventLog.WriteInfoLog(string.Format(@"Service in Run As Admin mode"));

                    SafeInstallService(serviceName);

                    // Run Service
                    StartService(serviceName);
                }
                else // Service Running ...
                {
                    ServiceBase.Run(services.ToArray());
                }
            }
        }

        public static bool InstallService()
        {
            try
            {
                WindowsEventLog.WriteInfoLog(string.Format(@"Installing Service"));
                ManagedInstallerClass.InstallHelper(new string[] { ExePath });
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool UninstallService()
        {
            try
            {
                WindowsEventLog.WriteInfoLog(string.Format(@"Uninstalling Service"));
                ManagedInstallerClass.InstallHelper(new string[] { "/u", ExePath });
            }
            catch
            {
                return false;
            }
            return true;
        }

        private static bool IsInstalled(string serviceName)
        {
            using (var controller = new ServiceController(serviceName))
            {
                try
                {
                    var status = controller.Status;
                }
                catch
                {
                    return false;
                }

                return true;
            }
        }

        private static bool IsRunning(string serviceName)
        {
            using (var controller = new ServiceController(serviceName))
            {
                if (!IsInstalled(serviceName)) return false;

                return (controller.Status == ServiceControllerStatus.Running);
            }
        }

        private static AssemblyInstaller GetInstaller(this Type serviceType)
        {
            var installer = new AssemblyInstaller(serviceType.Assembly, null)
            {
                UseNewContext = true
            };
            return installer;
        }

        private static void StartService(string serviceName)
        {
            if (!IsInstalled(serviceName)) return;

            using (var controller = new ServiceController(serviceName))
            {
                try
                {
                    WindowsEventLog.WriteInfoLog(string.Format(@"Trying to Start the Service..."));

                    if (controller.Status != ServiceControllerStatus.Running)
                    {
                        controller.Start();
                        controller.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                    }
                }
                catch (Exception ex)
                {
                    WindowsEventLog.WriteErrorLog(string.Format(@"\nError in starting service method \n{0}", ex.Message));
                }
            }
        }

        private static void StopService(string serviceName)
        {
            if (!IsInstalled(serviceName)) return;
            using (var controller = new ServiceController(serviceName))
            {
                try
                {
                    WindowsEventLog.WriteInfoLog(string.Format(@"Trying to Stop the Service..."));

                    if (controller.Status != ServiceControllerStatus.Stopped)
                    {
                        controller.Stop();
                        controller.WaitForStatus(ServiceControllerStatus.Stopped,
                            TimeSpan.FromSeconds(10));
                    }
                }
                catch (Exception ex)
                {
                    WindowsEventLog.WriteErrorLog(string.Format(@"\nError in stopping service method \n{0}", ex.Message));
                }
            }
        }

        public static void SafeInstallService(string serviceName, params string[] args)
        {
            if (!IsAdmin())
            {
                RestartElevated(ExePath, args);
                System.Environment.Exit(1);
            }

            SafeUninstallService(serviceName, args);

            // Install service 
            InstallService();
        }

        public static void SafeUninstallService(string serviceName, string[] args)
        {
            if (IsInstalled(serviceName)) // If service already installed then must uninstall them
            {
                if (!IsAdmin())
                {
                    RestartElevated(ExePath, args);
                    System.Environment.Exit(1);
                }

                if (IsRunning(serviceName)) StopService(serviceName);
                UninstallService();
            }
        }

        /// <summary>
        /// Is application running as administrator?
        /// </summary>
        /// <returns>Yes or No?</returns>
        public static bool IsAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();

            if (identity != null)
                return (new WindowsPrincipal(identity)).IsInRole(WindowsBuiltInRole.Administrator);

            return false;
        }

        public static void RestartElevated(string fileName, params string[] args)
        {
            String[] argumentsArray = Environment.GetCommandLineArgs();
            String argumentsLine = String.Empty;

            for (Int32 i = 1; i < argumentsArray.Length; ++i)
                argumentsLine += "\"" + argumentsArray[i] + "\" ";

            ProcessStartInfo info = new ProcessStartInfo();
            info.Arguments = argumentsLine.TrimEnd();
            info.FileName = fileName;
            info.UseShellExecute = true;
            info.Verb = "runas";
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
