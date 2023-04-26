using BeautyBookCustomerApp.Models;
using BeautyBookCustomerApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text;
using Xamarin.Essentials;

namespace BeautyBookCustomerApp.ViewModel
{
    public class BookingPage3ViewModel:BaseViewModel
    {
        Database _firebase;
        private ObservableCollection<BookingModelPage3> _profile;
        private ObservableCollection<BookingModelPage3> _myProfile;
        private static string _UserIdSalon { get; set; }
        public ObservableCollection<BookingModelPage3> Profile
        {
            get { return _profile; }
            set
            {
                _profile = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<BookingModelPage3> Myprofile
        {
            get
            {
                return _myProfile;
            }
            set
            {
                _myProfile = value;
                OnPropertyChanged();
            }
        }
        private async void localStorge()
        {
            try
            {
                var localStorge = await SecureStorage.GetAsync("ouserIdSalon");
                _UserIdSalon = localStorge;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
   
        public BookingPage3ViewModel(string time ,string date,string userID)
        {

            localStorge();
            _firebase = new Database();
            Myprofile = new ObservableCollection<BookingModelPage3>();
            Profile = new ObservableCollection<BookingModelPage3>();
            Profile = _firebase.BookingPage();
            Profile.CollectionChanged += Serviceschanged;
            _date = date;
            _time = time;
            _userId = userID;
            
          
        }
        private string _salonName;
        public string SalonName
        {
            get { return _salonName; }
            set
            {
                _salonName = value;
                OnPropertyChanged();
            }
        }
        private string _userId;
        public string userId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                OnPropertyChanged();
            }
        }

        private string _time;
        public string time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        private string _date;
        public string date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        private void Serviceschanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                BookingModelPage3 profilePageModel = e.NewItems[0] as BookingModelPage3;
                if (profilePageModel.userID == userId)    
                {
                    SalonName = profilePageModel.salonName;
                    Myprofile.Add(profilePageModel);
                }
            }
        }
    }
}