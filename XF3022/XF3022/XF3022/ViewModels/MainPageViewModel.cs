using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF3022.ViewModels
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
        public ObservableCollection<string> Picker1Source { get; set; } =
            new ObservableCollection<string>();
        public ObservableCollection<string> Picker2Source { get; set; } =
            new ObservableCollection<string>();
        public string Picker1SelectedItem { get; set; }
        public string Picker2SelectedItem { get; set; }
        void OnPicker1SelectedItemChanged()
        {
            try
            {
                if (Picker1SelectedItem != null)
                {
                    var temp = GenPicker2(Picker1SelectedItem);
                    Picker2Source.Clear();
                    foreach (var item in temp)
                    {
                        Picker2Source.Add(item);
                    }
                }
            }
            catch { }
        }
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var temp = GenPicker1();
            Picker1Source.Clear();
            foreach (var item in temp)
            {
                Picker1Source.Add(item);
            }
        }

        List<string> GenPicker1()
        {
            List<string> result = new List<string>();
            result.Add("A");
            result.Add("B");
            result.Add("C");
            result.Add("D");
            return result;
        }
        List<string> GenPicker2(string src)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                result.Add($"{src}{i}");
            }
            return result;
        }
        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
