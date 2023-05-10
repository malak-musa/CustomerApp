using BeautyBookCustomerApp.Services;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Xamarin.Forms;using Xamarin.Forms.Xaml;namespace BeautyBookCustomerApp.Views{    [XamlCompilation(XamlCompilationOptions.Compile)]    public partial class LoginPage : ContentPage    {

        public LoginPage()        {
            InitializeComponent();        }

        private void OnSignupLabelTapped(object sender, EventArgs e)        {            Navigation.PushAsync(new SignupPage());        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }}