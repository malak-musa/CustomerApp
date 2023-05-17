using BeautyBookAdminApp.Models;
using BeautyBookCustomerApp.Services;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.CommunityToolkit;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Nest;
using BeautyBookCustomerApp.Models;

namespace BeautyBookCustomerApp.ViewModels
{
    public class UserProfileViewModel : BaseViewModel
    {
        Database database;

        private FirebaseObject<SalonInformationModel> _salonDetails;
        public FirebaseObject<SalonInformationModel> SalonDetails
        {
            get => _salonDetails;
            set => SetProperty(ref _salonDetails, value);
        }

        public string SalonName => _salonDetails.Object.SalonName;

        public ObservableRangeCollection<FirebaseObject<BookingModel>> RequestedList { get; set; }
        public ICommand DeleteBookingCommand { set; get; }
        public ICommand OnApperingCommand { set; get; }

        public UserProfileViewModel()
        {
            RequestedList = new ObservableRangeCollection<FirebaseObject<BookingModel>>();
            database = new Database();
            DeleteBookingCommand = new Command<FirebaseObject<BookingModel>>(DeleteBooking);
            OnApperingCommand = new Command(OnAppearing);
        }

        async void DeleteBooking(FirebaseObject<BookingModel> selectedBook)
        {
            //System.Console.WriteLine(selectedBook);
            var isDeleted = await database.DeleteBooking(selectedBook);
            if (isDeleted)
            {
                RequestedList.Remove(selectedBook);

            }
        }

        async void OnAppearing()
        {
            string userID = await SecureStorage.GetAsync("oauth_token");
            var BookingList = await database.GetBooking(userID);
            if (BookingList != null)
            {
                RequestedList.AddRange(BookingList);

            }
        }

    }
}