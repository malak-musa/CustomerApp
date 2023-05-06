using BeautyBookCustomerApp.Models;
using BeautyBookCustomerApp.Services;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace BeautyBookCustomerApp.ViewModel
{
    public class MainPageViewModel : ObservableObject
    {
        public Database database;
        FirebaseObject<SalonInformationModel> _selectedItem;
        public FirebaseObject<SalonInformationModel> SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != null)
                    _selectedItem = null;

                OnPropertyChanged(nameof(RequestedList));
            }
        }
        public List<FirebaseObject<SalonInformationModel>> RequestedList { set; get; }
        public MainPageViewModel()
        {
            database = new Database();
            var t = Task.Run(async () =>
            {
                RequestedList = await database.GetSalons();
                
    });
            t.Wait();
        }
    }
}
