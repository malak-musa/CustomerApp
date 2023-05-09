﻿using BeautyBookCustomerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Newtonsoft.Json;
using Nest;
using System.Linq;
using Xamarin.Essentials;
using BeautyBookAdminApp.Models;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

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
            var customerInfo = await firebaseClient.Child(nameof(CustomerModel)).OnceAsync<CustomerModel>();

            foreach (var item in customerInfo)
            {
                if (item.Object.Username == Username && item.Object.Password == Password)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> SaveAppointmentInformation(BookingModel bookingInfo)
        {
            var data = await firebaseClient.Child(nameof(BookingModel)).PostAsync(JsonConvert.SerializeObject(bookingInfo));

            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;

            }

            return false;
        }

        public async Task<List<FirebaseObject<SalonInformationModel>>> GetSalons()
        {
            var requestedList = await firebaseClient.Child("SalonProfile").OnceAsync<SalonInformationModel>();

            return requestedList.ToList();

        }
        public async Task<bool> DeleteBooking(FirebaseObject<BookingModel> booking)
        {
            try
            {
                // Get a reference to the booking to be deleted
                var bookingRef = firebaseClient.Child("BookingModel").Child(booking.Key);

                // Delete the booking
                await bookingRef.DeleteAsync();

                // Remove the booking from the local collection
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting booking: {ex.Message}");
                return false;
            }
        }
        public async Task<List<FirebaseObject<BookingModel>>> GetBooking()
        {
            try
            {
               var booking=await firebaseClient.Child("BookingModel").OnceAsync<BookingModel>();
                return booking.ToList();

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        /*public async Task<List<SalonInformationModel>> GetSalonsAsync()
        {
            var salons = await firebaseClient.Child(nameof(SalonInformationModel)).OnceAsync<SalonInformationModel>();
            return salons.Select(x => x.Object).ToList();
        }*/

        /*public async Task<List<SalonInformationModel>> GetAllSalons()
        {
            return (await firebaseClient.Child(nameof(SalonInformationModel)).OnceAsync<SalonInformationModel>()).Select(salon => new SalonInformationModel
            {
                password = salon.Object.password,
                salonName = salon.Object.salonName,
                salonType = salon.Object.salonType,
                userID = salon.Object.userID,
                address = salon.Object.address,
                city = salon.Object.city,
                services = salon.Object.services,
                openingHours = salon.Object.openingHours,
                dayOff = salon.Object.dayOff
            }).ToList();
        }*/

        /*public async Task<List<SalonInformationModel>> GetAllSalons()
        {
            var salonList = (await firebaseClient
                .Child(nameof(SalonInformationModel))
                .OnceAsync<SalonInformationModel>())
                .Select(salon => new SalonInformationModel
                {
                    salonName = salon.Object.salonName,
                    address = salon.Object.address,
                    phoneNumber = salon.Object.phoneNumber
                }).ToList();

            return salonList;
        }*/
    }
}
