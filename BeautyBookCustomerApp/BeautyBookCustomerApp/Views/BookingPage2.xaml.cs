﻿using BeautyBookCustomerApp.Models;
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
        List<string> serviceListParameter;
        ObservableCollection<TimeModel> timeModel;

        public BookingPage2(List<string> ServiceList)
        {
            InitializeComponent();

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
            serviceListParameter = ServiceList;
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
            await Navigation.PushAsync(new BookingPage3("s", "24/5/2023", "9:90"));
        }
    }
}