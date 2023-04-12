using BeautyBookCustomerApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeautyBookCustomerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new BookingPage1());
            //MainPage = new NavigationPage(new LoginPage());
            MainPage = new NavigationPage(new SalonProfilePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
