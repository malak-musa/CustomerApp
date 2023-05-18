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
        public ObservableRangeCollection<FirebaseObject<BookingModel>> RequestedList { get; set; }
        public ICommand DeleteBookingCommand { set; get; }
        public ICommand OnApperingCommand { set; get; }
        public string SalonName => _salonDetails.Object.SalonName;
        
        private FirebaseObject<SalonInformationModel> _salonDetails;
        public FirebaseObject<SalonInformationModel> SalonDetails
        {
            get => _salonDetails;
            set => SetProperty(ref _salonDetails, value);
        }

        AuthModel _userInfo;
        public AuthModel UserInfo
        {
            set
            {
                _userInfo= value;
                OnPropertyChanged();
            }
            get
            {
                return _userInfo;
            }
        }

        public UserProfileViewModel()
        {
            RequestedList = new ObservableRangeCollection<FirebaseObject<BookingModel>>();
            database = new Database();
            DeleteBookingCommand = new Command<FirebaseObject<BookingModel>>(DeleteBooking);
            OnApperingCommand = new Command(OnAppearing);
        }

        async void DeleteBooking(FirebaseObject<BookingModel> selectedBook)
        {
            var isDeleted = await database.DeleteBooking(selectedBook);

            if (isDeleted)
            {
                RequestedList.Remove(selectedBook);
            }
        }

        async void OnAppearing()
        {
            string userID = await SecureStorage.GetAsync("oauth_token");
            UserInfo=await database.GetUserInfo(userID);
            var BookingList = await database.GetBooking(userID);

            if (BookingList != null)
            {
                RequestedList.AddRange(BookingList);
            }
        }
    }
}