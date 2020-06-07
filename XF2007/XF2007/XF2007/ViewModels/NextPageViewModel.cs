using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XF2007.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class NextPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public int Sum { get; set; }
        public string Response { get; set; }
        public DelegateCommand GobackCommand { get; set; }
        public NextPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            GobackCommand = new DelegateCommand(OnGobackCommand);
        }

        private void OnGobackCommand()
        {
            var para = new NavigationParameters();
            para.Add("Response", Response);
            navigationService.GoBackAsync(para);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            int v1 = parameters.GetValue<int>("V1");
            int v2 = parameters.GetValue<int>("V2");
            Sum = v1 + v2;
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
