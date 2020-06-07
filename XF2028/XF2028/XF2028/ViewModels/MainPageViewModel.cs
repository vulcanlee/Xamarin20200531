using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF2028.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        private readonly IStatusBarOnOff statusBarOnOff;

        public DelegateCommand OnCommand { get; set; }
        public DelegateCommand OffCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService,
            IStatusBarOnOff statusBarOnOff)
        {
            this.navigationService = navigationService;
            this.statusBarOnOff = statusBarOnOff;
            OnCommand = new DelegateCommand(OnOnCommand);
            OffCommand = new DelegateCommand(OnOffCommand);
        }

        private void OnOffCommand()
        {
            statusBarOnOff.TurnOff();
        }

        private void OnOnCommand()
        {
            statusBarOnOff.TurnOn();
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
