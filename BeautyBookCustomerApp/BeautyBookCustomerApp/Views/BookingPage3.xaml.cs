<<<<<<< Updated upstream
﻿using BeautyBookCustomerApp.Models;
using BeautyBookCustomerApp.Services;
using Firebase.Auth.Providers;
using Firebase.Auth;
=======
using BeautyBookCustomerApp.ViewModel;
using Nest;
>>>>>>> Stashed changes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
<<<<<<< Updated upstream
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            BookingModel bookingModel = new BookingModel();

            bookingModel.Date = selectedDateLabel.Text;
            bookingModel.Time = selectedTimeLabel.Text;
            bookingModel.Services = service;
            bookingModel.SalonName = SalonNameLabel.Text;
            //bookingModel.CustomerPhone =  ;

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
=======
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace BeautyBookCustomerApp.Views { 
    [XamlCompilation(XamlCompilationOptions.Compile)]
public partial class BookingPage3 : ContentPage
{
    public BookingPage3(string time, string date, string userID)
    {
        InitializeComponent();
        BookingPage3ViewModel bookingPage3ViewModel = new BookingPage3ViewModel(time, date, userID);
        BindingContext = new BookingPage3ViewModel(time, date, userID);
>>>>>>> Stashed changes
    }



    private void ConfirmButton_Clicked(object sender, EventArgs e)
    { }
} 
}