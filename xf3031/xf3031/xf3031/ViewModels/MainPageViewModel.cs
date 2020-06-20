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
        public DelegateCommand RefreshCommand { get; set; }
        public bool IsRefreshing { get; set; }
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            ItemSelectedCommand = new DelegateCommand(() =>
            {
                NavigationParameters para = new NavigationParameters();
                para.Add("MyTaskSelectedItem", MyTaskSelectedItem.Clone());
                navigationService.NavigateAsync("DetailPage", para);
            });
            RefreshCommand = new DelegateCommand(() =>
            {
                IsRefreshing = true;
                MyTaskRepository repository = new MyTaskRepository();
                var tasks = repository.GetMyTask();
                foreach (var item in tasks)
                {
                    MyTaskItemList.Add(item);
                }
                IsRefreshing = false;
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.GetNavigationMode() == NavigationMode.New)
            {
                MyTaskRepository repository = new MyTaskRepository();
                var tasks = repository.GetMyTask();
                foreach (var item in tasks)
                {
                    MyTaskItemList.Add(item);
                }
            }
            else
            {
                if (parameters.ContainsKey("Mode"))
                {
                    var Mode = parameters.GetValue<string>("Mode");
                    MyTaskItem item = parameters
                        .GetValue<MyTaskItem>("MyTaskSelectedItem");
                    if (Mode == "修改")
                    {
                        MyTaskItem UpdateRecore =
                            MyTaskItemList
                            .FirstOrDefault(x => x.MyTaskName == item.MyTaskName);
                        if (UpdateRecore != null)
                        {
                            UpdateRecore.MyTaskDate = item.MyTaskDate;
                            UpdateRecore.MyTaskStatus = item.MyTaskStatus;
                        }
                    }
                    if (Mode == "刪除")
                    {
                        MyTaskItem DeleteRecore =
                            MyTaskItemList
                            .FirstOrDefault(x => x.MyTaskName == item.MyTaskName);
                        if (DeleteRecore != null)
                        {
                            MyTaskItemList.Remove(DeleteRecore);
                        }
                    }
                }
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
