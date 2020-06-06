using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF1012.ViewModels
{
    using System.ComponentModel;
    using System.Net.Http;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public int Seconds { get; set; }
        public string Sum { get; set; }
        public bool IsRunning { get; set; } = false;
        public DelegateCommand SumCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            SumCommand = new DelegateCommand(OnSumCommand);
        }

        private async void OnSumCommand()
        {
            IsRunning = true;
            string url = 
                $"https://lobworkshop.azurewebsites.net/api/RemoteSource/Add/{Value1}/{Value2}/{Seconds}";
            HttpClient client = new HttpClient();
            Sum =await client.GetStringAsync(url);
            IsRunning = false;
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
