using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFQR.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using ZXing;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public string QRType { get; set; }
        public string QRContent { get; set; }
        public DelegateCommand ScanCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            ScanCommand = new DelegateCommand(OnScanCommand);
        }

        private void OnScanCommand()
        {
            navigationService.NavigateAsync("ScanPage");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var result = parameters.GetValue<Result>("Result");
            if (result != null)
            {
                QRType = result.BarcodeFormat.ToString();
                QRContent = result.Text;
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
