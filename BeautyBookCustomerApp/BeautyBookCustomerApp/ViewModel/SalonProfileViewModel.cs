using BeautyBookCustomerApp.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;

namespace BeautyBookCustomerApp.ViewModel
{
    public class SalonProfileViewModel : ObservableObject
    {
        private FirebaseObject<SalonInformationModel> _salonDetails;
        public string SalonName => _salonDetails.Object.SalonName;
        public string Phone => _salonDetails.Object.PhoneNumber;
        public string Location => _salonDetails.Object.Address;
        public string SalonType => _salonDetails.Object.SalonType;
        public string OpeningHours => _salonDetails.Object.OpeingHoures;

        public FirebaseObject<SalonInformationModel> SalonDetails
        {
            get => _salonDetails;
            set => SetProperty(ref _salonDetails, value);
        }

        public SalonProfileViewModel()
        {
        }
    }
}
