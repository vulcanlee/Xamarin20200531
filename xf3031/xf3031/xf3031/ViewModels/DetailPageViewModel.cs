using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace xf3031.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class DetailPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public MyTaskItem MyTaskSelectedItem { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        public DetailPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            SaveCommand = new DelegateCommand(OnSaveCommand);
            DeleteCommand = new DelegateCommand(OnDeleteCommand);
        }

        private void OnDeleteCommand()
        {
            NavigationParameters para = new NavigationParameters();
            para.Add("MyTaskSelectedItem", MyTaskSelectedItem);
            para.Add("Mode", "刪除");
            navigationService.GoBackAsync(para);
        }

        private void OnSaveCommand()
        {
            NavigationParameters para = new NavigationParameters();
            para.Add("MyTaskSelectedItem", MyTaskSelectedItem);
            para.Add("Mode", "修改");
            navigationService.GoBackAsync(para);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            MyTaskSelectedItem = parameters
                .GetValue<MyTaskItem>("MyTaskSelectedItem");
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
