using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyBookCustomerApp.Models
{
    public class AuthModel
    {
        public string UserId { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }   
        public string PhoneNumber {set; get; }
        public string Username { set; get; }
        public string FullName { set; get; }
    }
}
