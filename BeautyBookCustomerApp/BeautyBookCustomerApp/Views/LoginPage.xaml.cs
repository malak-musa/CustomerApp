using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeautyBookCustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (PasswordEntry.Text == "user@gmail.com" && UsernameEntry.Text == "123456")
            {
                //Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert("Ops..", "Username or Password is incorrect!", "OK");
            }
        }

        private void OnSignupLabelTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignupPage());
        }
    }
}