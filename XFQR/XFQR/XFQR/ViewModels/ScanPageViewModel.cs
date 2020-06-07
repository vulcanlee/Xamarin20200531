using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFQR.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Forms;
    using ZXing;

    public class ScanPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public bool IsAnalyzing { get; set; }
        public bool IsScanning { get; set; }
        public Result ScanResult { get; set; }
        public DelegateCommand ScanResultCommand { get; set; }
        public ScanPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            ScanResultCommand = new DelegateCommand(OnScanResultCommand);
            IsAnalyzing = true;
            IsScanning = true;
        }

        private void OnScanResultCommand()
        {
            // UI Thread (Main /UI 執行緒)
            Device.BeginInvokeOnMainThread(() =>
            {
                var para = new NavigationParameters();
                para.Add("Result", ScanResult);
                navigationService.GoBackAsync(para);
            });
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
