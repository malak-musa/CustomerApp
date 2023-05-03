using BeautyBookCustomerApp.Models;
using BeautyBookCustomerApp.Services;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text;
using Xamarin.Essentials;

namespace BeautyBookCustomerApp.ViewModel
{
    public class SalonProfileViewModel:BaseViewModel
    {
        Database _firebase;
        private ObservableCollection<SalonInformationModel> _profile;
        private ObservableCollection<SalonInformationModel> _myProfile;
   

        public SalonProfileViewModel(string userID) {
           
            _firebase = new Database();
         
            Profile = new ObservableCollection<SalonInformationModel>();
            Profile = _firebase.getSalonProfile();
            Profile.CollectionChanged += Serviceschanged;
            _userId = userID;
           
        }

      
        public ObservableCollection<SalonInformationModel> Profile
        {
            get { return _profile; }
            set
            {
                _profile = value;
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
        private string _ImagURL;
        public string ImagURL
        {
            get { return _ImagURL; }
            set
            {
                _ImagURL = value;
                OnPropertyChanged();
            }
        }
        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        private string _daysOff;
        public string DaysOff
        {
            get { return _daysOff; }
            set
            {
                _daysOff = value;
                OnPropertyChanged();
            }
        }

        private string _opeingHoures;
        public string OpeingHoures
        {
            get { return _opeingHoures; }
            set
            {
                _opeingHoures = value;
                OnPropertyChanged();
            }
        }

        private string _salonType;
        public string SalonType
        {
            get { return _salonType; }
            set
            {
                _salonType = value;
                OnPropertyChanged();
            }
        }
     

        private void Serviceschanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                SalonInformationModel profilePageModel = e.NewItems[0] as  SalonInformationModel;
                if (profilePageModel.userId == userId)
                {
                    SalonName = profilePageModel.SalonName;
                    Address = profilePageModel.Address;
                    DaysOff = profilePageModel.DaysOff;
                    OpeingHoures = profilePageModel.OpeingHoures;
                    ImagURL = profilePageModel.ImagURL;
                    SalonType = profilePageModel.SalonType;
                  
                    
                }
            }
        }

    }
}
