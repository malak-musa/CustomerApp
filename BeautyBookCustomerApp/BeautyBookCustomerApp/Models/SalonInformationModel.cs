using BeautyBookAdminApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyBookCustomerApp.Models
{
    public class SalonInformationModel
    {
        public string SalonName { get; set; }
        public string Address { get; set; } 
        public string OpeingHoures { get; set; }
        public string SalonType { get; set; }
        public string PhoneNumber { get; set; }
        public List<Service>? Services { get; set; }
        public string UserId { get; set; }
    }
}
