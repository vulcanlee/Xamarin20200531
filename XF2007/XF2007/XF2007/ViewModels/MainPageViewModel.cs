using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF2007.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public string FromNextPageMessage { get; set; }
        public DelegateCommand AddCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            AddCommand = new DelegateCommand(OnAddCommand);
        }

        private void OnAddCommand()
        {
            var para = new NavigationParameters();
            para.Add("V1", Value1);
            para.Add("V2", Value2);
            navigationService.NavigateAsync("NextPage", para);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var msg = parameters.GetValue<string>("Response");
            FromNextPageMessage = msg;
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
