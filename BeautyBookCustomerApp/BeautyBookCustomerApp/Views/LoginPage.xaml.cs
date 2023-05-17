using BeautyBookCustomerApp.Services;
using BeautyBookCustomerApp.ViewModel;
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
            BindingContext = new LoginViewModel();
            InitializeComponent();
        }

        private void OnSignupLabelTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignupPage());
        }
    }
}