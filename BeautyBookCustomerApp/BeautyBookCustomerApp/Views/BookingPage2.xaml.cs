using BeautyBookCustomerApp.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamForms.Controls;

namespace BeautyBookCustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingPage2 : ContentPage
    {
        private DateTime selectedDate;
        private static string selectedTime = null;
        private static Button previousButton = null;
        ObservableCollection<TimeModel> timeModel;

        public BookingPage2()
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
        }

        private void OnDateSelected(object sender, DateTimeEventArgs e)
        {
            selectedDate = e.DateTime;
        }

        private void SelectTime(object sender, EventArgs e)
        {
            var button = sender as Button;
            var time = button.BindingContext as string;
            //var text = button.Text;

            if (previousButton != null)
            {
                previousButton.TextColor = Color.Black;
                previousButton.BackgroundColor = Color.White;
                previousButton.BorderWidth = 1.5;
                previousButton.BorderColor = Color.LightGray;
            }

            selectedTime = time;
            button.BackgroundColor = Color.FromHex("#3C504C");
            button.BorderColor = Color.Transparent;
            button.TextColor = Color.White;

            previousButton = button;
        }

        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            //selectedDateLabel.Text = $"Selected date: {selectedDate.ToString("MM/dd/yyyy")}";
            selectedDateLabel.Text = $"Selected date: {selectedDate:MM/dd/yyyy}";
            await Navigation.PushAsync(new BookingPage3());
        }
    }
}