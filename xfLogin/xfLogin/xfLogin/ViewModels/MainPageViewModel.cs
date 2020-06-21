using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xfLogin.ViewModels
{
    using System.ComponentModel;
    using System.IO;
    using System.Net.Http;
    using Newtonsoft.Json;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public string Account { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public DelegateCommand LoginCommand { get; set; }

        string dataFile = System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Account.txt");

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            LoginCommand = new DelegateCommand(OnLoginCommand);
        }

        private async void OnLoginCommand()
        {
            HttpClient client = new HttpClient();
            LoginQueryString queryString = new LoginQueryString();
            queryString.Account = Account;
            queryString.Password = Password;
            string postPayload = JsonConvert.SerializeObject(queryString);

            StringContent content = new StringContent(postPayload, Encoding.UTF8,
                "application/json");


            var response = await client
                .PostAsync("https://contososyncfusion.azurewebsites.net/api/Login", content);

            if (response.IsSuccessStatusCode == false)
            {
                Message = "Http 呼叫失敗";
            }
            else
            {
                string strResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<StandardResponse<LoginData>>(strResult);
                if (result.Success == true)
                {
                    Message = ":身分驗證成功:";
                    File.WriteAllText(dataFile, Account);
                }
                else
                {
                    Message = result.ErrorMessage;
                }
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (File.Exists(dataFile) == true)
                Account = File.ReadAllText(dataFile);
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
