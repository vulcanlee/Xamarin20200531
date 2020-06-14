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
    public class LoginPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public string Account { get; set; }
        public string Password { get; set; }
        public bool ShowErrorMessage { get; set; } = false;
        public DelegateCommand LoginCommand { get; set; }
        public LoginPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            LoginCommand = new DelegateCommand(OnLoginCommand);
        }

        private void OnLoginCommand()
        {
            if(Account == "abc" && Password == "123")
            {
                navigationService.NavigateAsync("/MDPage/NavigationPage/MainPage");
            }
            else
            {
                ShowErrorMessage = true;
            }
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
