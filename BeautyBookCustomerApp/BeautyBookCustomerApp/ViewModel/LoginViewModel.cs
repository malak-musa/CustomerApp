using BeautyBookCustomerApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BeautyBookCustomerApp.ViewModel
{
    public class LoginViewModel
    {
        public string Email { set; get; }
        public string Password { set; get; }
        public ICommand LoginButton { get; }

        private readonly Database _firebase;

        public LoginViewModel()
        {
            _firebase = new Database();
            LoginButton = new Command(async () => await SignIn());
        }

        private async Task SignIn()
        {
            await _firebase.SingIn(Email, Password);
        }
    }
}
