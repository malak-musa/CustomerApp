using BeautyBookCustomerApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BeautyBookCustomerApp.Models
{
     class SignupModel
    {
        public string UserID { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string FullName { set; get; }
        public string PhoneNumber { set; get; }
        public string Username { get; set; }
       
    }
}
