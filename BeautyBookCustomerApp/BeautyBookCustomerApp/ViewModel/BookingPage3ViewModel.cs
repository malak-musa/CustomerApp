using BeautyBookCustomerApp.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;

namespace BeautyBookCustomerApp.ViewModel
{
    public class BookingPage3ViewModel : ObservableObject
    {
        public string SalonName => _salonDetails.Object.SalonName;

        private FirebaseObject<SalonInformationModel> _salonDetails;
        public FirebaseObject<SalonInformationModel> SalonDetails
        {
            get => _salonDetails;
            set => SetProperty(ref _salonDetails, value);
        }
    }
}