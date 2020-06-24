using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Friends.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Friends.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            string uuid = await SecureStorage.GetAsync("uuid");

            if (string.IsNullOrEmpty(uuid))
            {
                wview_login.IsVisible = true;
                wview_login.Source = $"{Constants.BaseURL}/oauth/begin";
            }
            else
            {
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        var json = wc.DownloadString($"{Constants.BaseURL}/oauth/userInfo?uuid={uuid}");
                    }

                    MainPage mainPage = new MainPage(uuid);
                    Application.Current.MainPage = mainPage;
                }
                catch (WebException)
                {
                    SecureStorage.Remove("uuid");
                    wview_login.IsVisible = true;
                    wview_login.Source = $"{Constants.BaseURL}/oauth/begin";
                }
            }
        }
        private async void wview_login_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (e.Url.Contains("oauth_verifier"))
            {
                wview_login.IsVisible = false;
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(e.Url);
                    WarwickLogin login_obj = JsonConvert.DeserializeObject<WarwickLogin>(json);
                    await SecureStorage.SetAsync("uuid", login_obj.uuid);
                    MainPage mainPage = new MainPage(login_obj.uuid);
                    Application.Current.MainPage = mainPage;
                }
            }
        }
    }
}