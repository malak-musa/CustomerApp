using BeautyBookCustomerApp.Services;
using Firebase.Auth.Providers;
using Firebase.Auth;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BeautyBookCustomerApp.Models;

namespace BeautyBookCustomerApp.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        Database _userDB = new Database();
        private const string FirebaseApiKey = "AIzaSyA37bTpBm27kjiHDuf5tigFwCmVsxmEYsY ";
        private const string FirebaseDatabaseUrl = "https://xamarinfirebase13-default-rtdb.firebaseio.com/";
        public SignupPage()
        {
             
            InitializeComponent();
        }

        private async void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            CustomerModel customer = new CustomerModel();
            customer.username = username.Text;
            customer.password = password.Text;
            customer.firstName = firstName.Text;
            customer.lastName = lastName.Text;
            customer.phoneNumber = phoneNumber.Text;

            try
            {

                if (string.IsNullOrEmpty(customer.username))
                {
                    await DisplayAlert("Warning", "Please enter your Username ", "Cancel");
                    return;
                }

                if (string.IsNullOrEmpty(customer.firstName))
                {
                    await DisplayAlert("Warning", "Please enter your First Name ", "Cancel");
                    return;
                }
                if (string.IsNullOrEmpty(customer.lastName))
                {
                    await DisplayAlert("Warning", "Please enter your Last Name ", "Cancel");
                    return;
                }

                if (customer.password.Length < 6)
                {
                    await DisplayAlert("Warning", "password should be more 6 digit", "Cancel");
                    return;
                }

                if (string.IsNullOrEmpty(customer.password))
                {
                    await DisplayAlert("Warning", "Please enter your password ", "Cancel");
                    return;
                }
        
                var config = new FirebaseAuthConfig
                {
                    ApiKey = FirebaseApiKey,
                    AuthDomain = "beautybookapp-a44e5.firebaseapp.com",
                    Providers = new FirebaseAuthProvider[] { new EmailProvider() }
                };

                bool isSave = await _userDB.SaveCustomerInfo(customer);
                if (isSave)
                {
                    await DisplayAlert("Register user", "Regestiration compleated ", "ok");
                    await Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    await DisplayAlert("Register user", "Regestiration faild ", "ok");

                }
            }
            catch (Exception exception)
            {
                await DisplayAlert("Errore", exception.Message, "ok");
            }


        }
    }

    }
