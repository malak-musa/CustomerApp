using BeautyBookCustomerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Newtonsoft.Json;
using Nest;
using System.Collections.ObjectModel;

namespace BeautyBookCustomerApp.Services
{
    public class Database
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://beautybookapp-a44e5-default-rtdb.europe-west1.firebasedatabase.app/");

        public async Task<bool> SaveCustomerInfo(CustomerModel salon)
        {
            var data = await firebaseClient.Child(nameof(CustomerModel)).PostAsync(JsonConvert.SerializeObject(salon));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;

            }
            return false;
        }


        public async Task<bool> Login(string Username, string Password)
        {
            var salonInfo = await firebaseClient.Child(nameof(CustomerModel)).OnceAsync<CustomerModel>();

            foreach (var item in salonInfo)
            {
                if (item.Object.Username == Username && item.Object.Password == Password)
                {
                    return true;
                }
            }

            return false;
        }
        public ObservableCollection<BookingModelPage3> BookingPage()
        {
            var Users_Customer = firebaseClient.Child("Salon").AsObservable<BookingModelPage3>().AsObservableCollection();


            return Users_Customer;
        }
    }

}
