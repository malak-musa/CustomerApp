﻿using BeautyBookCustomerApp.Models;
using BeautyBookCustomerApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BeautyBookCustomerApp.ViewModel
{
    public class SignupViewModel
    {
        public SignupViewModel()
        {
            _firebase = new Database();


            SigUpButton = new Command(async () => await AddUser());
        }
        public string UserID { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string FullName { set; get; }
        public string PhoneNumber { set; get; }
        public string Username { get; set; }
        public ICommand SigUpButton { get; }
        private Database _firebase;
        public IList<CustomerModel> Cities { get; set; }
        private async Task AddUser()
        {
            AuthModel addUser = new AuthModel();
            {
                addUser.Username = Username;
                addUser.PhoneNumber = PhoneNumber;
                addUser.FullName = FullName;
                addUser.Email = Email;

            }
            await _firebase.SingUp(addUser, Email, Password);
        }
    }
}
