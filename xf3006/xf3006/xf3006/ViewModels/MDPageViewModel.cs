using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace xf3006.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MDPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public DelegateCommand GoHomeCommand { get; set; }
        public DelegateCommand GoPage1Command { get; set; }
        public DelegateCommand GoPage2Command { get; set; }
        public MDPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            GoHomeCommand = new DelegateCommand(OnGoHomeCommand);
            GoPage1Command = new DelegateCommand(OnGoPage1Command);
            GoPage2Command = new DelegateCommand(OnGoPage2Command);
        }

        private void OnGoPage2Command()
        {
            navigationService.NavigateAsync("/MDPage/NavigationPage/Page2Page");
        }

        private void OnGoPage1Command()
        {
            navigationService.NavigateAsync("/MDPage/NavigationPage/MainPage/Page1Page");
        }

        private void OnGoHomeCommand()
        {
            navigationService.NavigateAsync("/MDPage/NavigationPage/MainPage");
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
