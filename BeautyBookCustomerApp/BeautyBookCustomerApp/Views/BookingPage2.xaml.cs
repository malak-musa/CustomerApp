using BeautyBookCustomerApp.Models;
using BeautyBookCustomerApp.ViewModel;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamForms.Controls;

namespace BeautyBookCustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingPage2 : ContentPage
    {
        public DateTime selectedDate;
        private static Button previousTimeButton = null;
        private static string selectedTime = null;
        public string selectedTimeText = null;
        readonly int serviceNumParameter;
        readonly ObservableCollection<TimeModel> timeModel;

        FirebaseObject<SalonInformationModel> Details { get; set; }
        public BookingPage2(int ServiceNum, FirebaseObject<SalonInformationModel> details)
        {
            InitializeComponent();

            Details = details;

            Calendar.MinDate = DateTime.Today;

            Calendar.DateClicked += OnDateSelected;

            timeModel = new ObservableCollection<TimeModel>
            {
                new TimeModel{Time = "09:00 AM"},
                new TimeModel{Time = "10:00 AM"},
                new TimeModel{Time = "11:00 AM"},
                new TimeModel{Time = "12:00 PM"},
                new TimeModel{Time = "01:00 PM"},
                new TimeModel{Time = "02:00 PM"},
                new TimeModel{Time = "03:00 PM"},
                new TimeModel{Time = "04:00 PM"},
                new TimeModel{Time = "05:00 PM"},
                new TimeModel{Time = "06:00 PM"},
            };

            Times.ItemsSource = timeModel;
            serviceNumParameter = ServiceNum;
        }

        private void OnDateSelected(object sender, DateTimeEventArgs e)
        {
            selectedDate = e.DateTime;
        }

        private void SelectTime(object sender, EventArgs e)
        {
            var button = sender as Button;
            var time = button.BindingContext as string;
            selectedTimeText = button.Text;

            if (previousTimeButton != null)
            {
                previousTimeButton.TextColor = Color.Black;
                previousTimeButton.BackgroundColor = Color.White;
                previousTimeButton.BorderWidth = 1.5;
                previousTimeButton.BorderColor = Color.LightGray;

                previousTimeButton.IsVisible = true;
            }

            selectedTime = time;
            button.BackgroundColor = Color.FromHex("#3C504C");
            button.BorderColor = Color.Transparent;
            button.TextColor = Color.White;

            previousTimeButton = button;

            button.IsVisible = false;
        }

        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            if (selectedDate == DateTime.MinValue)
            {
                await Application.Current.MainPage.DisplayAlert("sorry", "you should select time", "ok");
                return;
            }
            await Navigation.PushAsync(new BookingPage3(serviceNumParameter, selectedDate, selectedTimeText, Details));
        }
    }
}