using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reflection;
using System.ServiceProcess;
using ServiceProcess.Helpers.ViewModels;

namespace ServiceProcess.Helpers.Helpers
{
    internal static class ServiceBaseHelpers
    {
        internal static class Operations
        {
            public static readonly Operation Start    = new Operation { MethodCall = "OnStart",    InitialState = ServiceState.Starting, FinishedState = ServiceState.Started, ErrorState = ServiceState.Stopped };
            public static readonly Operation Stop     = new Operation { MethodCall = "OnStop",     InitialState = ServiceState.Stopping, FinishedState = ServiceState.Stopped, ErrorState = ServiceState.Stopped };
            public static readonly Operation Pause    = new Operation { MethodCall = "OnPause",    InitialState = ServiceState.Pausing,  FinishedState = ServiceState.Paused,  ErrorState = ServiceState.Stopped };
            public static readonly Operation Continue = new Operation { MethodCall = "OnContinue", InitialState = ServiceState.Starting, FinishedState = ServiceState.Started, ErrorState = ServiceState.Stopped } ;
        }

        internal class Operation
        {
            public string MethodCall { get; set; }
            public ServiceState InitialState { get; set; }
            public ServiceState FinishedState { get; set; }
            public ServiceState ErrorState { get; set; }
        }

        internal static IObservable<ServiceState> StartService(ServiceBase service)
        {
            return CallOperationOnService(service, Operations.Start);
        }

        internal static IObservable<ServiceState> StopService(ServiceBase service)
        {
            return CallOperationOnService(service, Operations.Stop);
        }

        internal static IObservable<ServiceState> PauseService(ServiceBase service)
        {
            return CallOperationOnService(service, Operations.Pause);
        }

        internal static IObservable<ServiceState> ContinueService(ServiceBase service)
        {
            return CallOperationOnService(service, Operations.Continue);
        }

        private static IObservable<ServiceState> CallOperationOnService(ServiceBase serviceBase, Operation operation)
        {
            ReplaySubject<ServiceState> result = new ReplaySubject<ServiceState>();
            result.OnNext(operation.InitialState);

            var methodObs = Observable.Start(() =>
                {
                    Type serviceBaseType = serviceBase.GetType();
                    object[] parameters = null;
                    if (operation == Operations.Start)
                    {
                        parameters = new object[] { null };
                    }

                    try
                    {
                        serviceBaseType.InvokeMember(operation.MethodCall, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, serviceBase, parameters);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("An exception was thrown while trying to call the {0} of the {1} service.  Examine the inner exception for more information.", operation, serviceBase.ServiceName), ex.InnerException);
                    }
                });

            methodObs.Subscribe
                (
                    _ =>
                    {
                        result.OnNext(operation.FinishedState);
                        result.OnCompleted();
                    }, 

                    ex =>
                    {
                        result.OnNext(operation.ErrorState);
                        result.OnError(ex);
                    }
                );

            return result;
        }
    }
}