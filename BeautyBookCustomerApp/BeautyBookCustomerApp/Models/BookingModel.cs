using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyBookCustomerApp.Models
{
    public class BookingModel
    {
        public string SalonName { get; set; }
        public string CustomerName { get; set; }
        public int CustomerPhone { get; set; }
        public List<string> Services { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        
    }
}
