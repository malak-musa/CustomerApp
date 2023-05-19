using BeautyBookAdminApp.Models;
using BeautyBookCustomerApp.Models;
using BeautyBookCustomerApp.Services;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BeautyBookCustomerApp.ViewModel
{
    public class BookingPage1ViewModel : ObservableObject
    {
        public Database database;
        public ICommand OnApperingCommand { set; get; }
        public ObservableRangeCollection<FirebaseObject<SalonInformationModel>> RequestedList { set; get; }

        private FirebaseObject<SalonInformationModel> _salonDetails;

        public FirebaseObject<SalonInformationModel> SalonDetails
        {
            get => _salonDetails;
            set => SetProperty(ref _salonDetails, value);
        }

        public BookingPage1ViewModel()
        {
            RequestedList = new ObservableRangeCollection<FirebaseObject<SalonInformationModel>>();
            database = new Database();
            OnApperingCommand = new Command(OnAppearing);
        }

        public async void OnAppearing()
        {
            var BookingList = await database.GetSalonServices(SalonDetails.Key);

            if (BookingList != null)
            {
                RequestedList.AddRange(BookingList);
            }
        }
    }
}
