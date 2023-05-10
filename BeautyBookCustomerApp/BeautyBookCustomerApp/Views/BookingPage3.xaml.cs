using BeautyBookCustomerApp.Models;
using BeautyBookCustomerApp.Services;
using Firebase.Auth.Providers;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BeautyBookAdminApp.Models;
using Xamarin.Essentials;
using Nest;

namespace BeautyBookCustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingPage3 : ContentPage
    {
        public DateTime date;
        public string time;
        public string service;
        Database _userDB = new Database();
        private const string FirebaseApiKey = "AIzaSyA37bTpBm27kjiHDuf5tigFwCmVsxmEYsY ";

        public BookingPage3(List<string> ServiceList, DateTime date, string time)
        {
            InitializeComponent();

            string concatenatedString = "";

            foreach (string s in ServiceList)
            {
                concatenatedString += s + "\n";

            }

            service = concatenatedString;

            selectedDateLabel.Text = $"Date: {date:MM/dd/yyyy}";
            selectedTimeLabel.Text = $"Time: {time}";
            selectedServices.Text = $"Services: {concatenatedString}";
        }

        private async void ConfirmButton_Clicked(object sender, EventArgs e)
        {
            BookingModel bookingModel = new BookingModel()
            {
                Date = selectedDateLabel.Text,
                Time = selectedTimeLabel.Text,
                Services = service,
                SalonName = SalonNameLabel.Text,
                //bookingModel.CustomerPhone =  ;
                UserId = await SecureStorage.GetAsync("oauth_token")
            };

            

            try
            {
                var config = new FirebaseAuthConfig
                {
                    ApiKey = FirebaseApiKey,
                    AuthDomain = "beautybookapp-a44e5.firebaseapp.com",
                    Providers = new FirebaseAuthProvider[] { new EmailProvider() }
                };

                bool isSave = await _userDB.SaveAppointmentInformation(bookingModel);

                if (isSave)
                {
                    await DisplayAlert("Booking", "Booking compleated", "ok");
                }
                else
                {
                    await DisplayAlert("Booking", "Booking faild ", "ok");
                }
            }
            catch (Exception exception)
            {
                await DisplayAlert("Error", exception.Message, "ok");
            }
        }
    }
}