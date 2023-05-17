using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyBookCustomerApp.Models
{
    public class SignupModel
    {
        public string Email { set; get; }
        public string Password { set; get; }
        public string FullName { set; get; }
        public string PhoneNumber { set; get; }
        public string Username { get; set; }
    }
}
