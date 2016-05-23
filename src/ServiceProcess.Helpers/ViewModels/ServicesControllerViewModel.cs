using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Xaml;

namespace ServiceProcess.Helpers.ViewModels
{
    internal class ServicesControllerViewModel : ReactiveObject
    {
        public IEnumerable<ServiceViewModel> Services { get; private set; }

        private ServiceViewModel _SelectedService = null;
        public ServiceViewModel SelectedService
        {
            get { return _SelectedService; }
            set { this.RaiseAndSetIfChanged(x => x.SelectedService, value); }
        }

        public ReactiveCommand StartCommand { get; private set; }
        public ReactiveCommand PauseCommand { get; private set; }
        public ReactiveCommand StopCommand { get; private set; }

        public ServicesControllerViewModel(IEnumerable<ServiceViewModel> serviceViewModels)
        {
            var selectedServiceObs = this.ObservableForProperty(x => x.SelectedService).Value();

            //Combine the latest value from either the start or continue executes
            //to determine if you can press the "play" button
            StartCommand = new ReactiveCommand
            (
                selectedServiceObs.SelectMany
                (
                    s => s.StartCommand.CanExecuteObservable.StartWith(true)
                        .CombineLatest
                        (
                            s.ContinueCommand.CanExecuteObservable.StartWith(false), 
                            (l,r) => l || r
                        )
                )
            );

            StopCommand = new ReactiveCommand(selectedServiceObs.SelectMany(s => s.StopCommand.CanExecuteObservable).StartWith(false));
            PauseCommand = new ReactiveCommand(selectedServiceObs.SelectMany(s => s.PauseCommand.CanExecuteObservable).StartWith(false));

            StartCommand
                .SelectMany
                (
                    _ => new ReactiveCommand[]
                    {
                        _SelectedService.StartCommand, 
                        _SelectedService.ContinueCommand
                    }
                    .Where(cmd => cmd.CanExecute(null))
                    .ToObservable()
                )
                .Do(cmd => cmd.Execute(null))
                .Subscribe();

            StopCommand.Subscribe(_ => SelectedService.StopCommand.Execute(null));
            PauseCommand.Subscribe(_ => SelectedService.PauseCommand.Execute(null));

            Services = serviceViewModels;
            SelectedService = Services.FirstOrDefault();
        }
    }
}
