using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xf3031.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public ObservableCollection<MyTaskItem> MyTaskItemList { get; set; } =
            new ObservableCollection<MyTaskItem>();
        public MyTaskItem MyTaskSelectedItem { get; set; }
        public DelegateCommand ItemSelectedCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            ItemSelectedCommand = new DelegateCommand(() =>
            {
                NavigationParameters para = new NavigationParameters();
                para.Add("MyTaskSelectedItem", MyTaskSelectedItem);
                navigationService.NavigateAsync("DetailPage", para);
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            MyTaskRepository repository = new MyTaskRepository();
            var tasks = repository.GetMyTask();
            foreach (var item in tasks)
            {
                MyTaskItemList.Add(item);
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
