using BeautyBookCustomerApp.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeautyBookCustomerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override async void OnStart()
        {
            /*var oauth_token = await SecureStorage.GetAsync("oauth_token");
            if (!string.IsNullOrEmpty(oauth_token))
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }*/
        }


        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
