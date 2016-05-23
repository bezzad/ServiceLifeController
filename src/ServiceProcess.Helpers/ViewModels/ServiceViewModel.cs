using System;
using System.Reactive.Linq;
using System.ServiceProcess;
using System.Windows;
using ReactiveUI;
using ReactiveUI.Xaml;
using ServiceProcess.Helpers.Helpers;

namespace ServiceProcess.Helpers.ViewModels
{
    internal class ServiceViewModel : ReactiveObject
    {
        public ReactiveCommand StartCommand { get; private set; }
        public ReactiveCommand PauseCommand { get; private set; }
        public ReactiveCommand StopCommand { get; private set; }
        public ReactiveCommand ContinueCommand { get; private set; }

        public string Name { get; private set; }

        private bool _IsBusy = false;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                this.RaiseAndSetIfChanged(x => x.IsBusy, value);
            }
        }

        private ServiceState _CurrentState = ServiceState.Stopped;
        public ServiceState CurrentState
        {
            get { return _CurrentState; }
            set { this.RaiseAndSetIfChanged(x => x.CurrentState, value); }
        }

        public ServiceViewModel(ServiceBase service)
        {
            Name = service.ServiceName;

            //Get an observable for the current state
            var currentStateObs = this.ObservableForProperty(x => x.CurrentState).Value().StartWith(ServiceState.Stopped);

            //Map an observable to IsBusy that is True if the current state is *ing
            currentStateObs.Select
            (
                s => s == ServiceState.Pausing ||
                     s == ServiceState.Starting ||
                     s == ServiceState.Stopping
            )
            .Subscribe(busy => IsBusy = busy);

            StartCommand    = new ReactiveCommand(currentStateObs.Select(s => s == ServiceState.Stopped));
            StopCommand     = new ReactiveCommand(currentStateObs.Select(s => s == ServiceState.Started || s == ServiceState.Paused));
            PauseCommand    = new ReactiveCommand(currentStateObs.Select(s => s == ServiceState.Started && service.CanPauseAndContinue));
            ContinueCommand = new ReactiveCommand(currentStateObs.Select(s => s == ServiceState.Paused && service.CanPauseAndContinue));

            AssignmentSubscription(StartCommand,    () => ServiceBaseHelpers.StartService(service));
            AssignmentSubscription(StopCommand,     () => ServiceBaseHelpers.StopService(service));
            AssignmentSubscription(PauseCommand,    () => ServiceBaseHelpers.PauseService(service));
            AssignmentSubscription(ContinueCommand, () => ServiceBaseHelpers.ContinueService(service));

            //
            // Start on start time
            //
            StartCommand.Execute(null);
        }

        private void AssignmentSubscription(ReactiveCommand command, Func<IObservable<ServiceState>> serviceOperation)
        {
            //with each firing of the command, create a new observable for the operation
            //and subscribe to state changes
            command.Subscribe
            (
                _ => serviceOperation()
                    .SubscribeOnDispatcher()
                    .Subscribe
                    (
                        s =>
                        {
                            CurrentState = s;
                        },
                        ex =>
                        {
                            //TODO: show something more serviceable than a MessageBox? Something that scrolls, maybe.
                            MessageBox.Show(ex.ToString());
                        }
                    )
            );
        }
    }
}