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

        readonly ObservableRangeCollection<Service> services;
        Service service;
        //---
        private ObservableRangeCollection<Service> _services;
        public ObservableRangeCollection<Service> serviceListView
        {
            get => _services;
            set => SetProperty(ref _services, value);
        }
        //---

        private FirebaseObject<SalonInformationModel> _salonDetails;

        public FirebaseObject<SalonInformationModel> SalonDetails
        {
            get => _salonDetails;
            set => SetProperty(ref _salonDetails, value);
        }

        public BookingPage1ViewModel()
        {
            database = new Database();
            OnApperingCommand = new Command(OnAppearing);

            services = new ObservableRangeCollection<Service>();
            serviceListView = new ObservableRangeCollection<Service>();
        }

        public async void OnAppearing()
        {
            var BookingList = await database.GetSalonServices(SalonDetails.Key);

            if (BookingList != null)
            {
                serviceListView.AddRange(BookingList);
            }
        }
    }
}
