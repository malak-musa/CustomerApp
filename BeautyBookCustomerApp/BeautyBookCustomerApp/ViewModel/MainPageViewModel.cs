using BeautyBookCustomerApp.Models;
using BeautyBookCustomerApp.Services;
using BeautyBookCustomerApp.Views;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace BeautyBookCustomerApp.ViewModel
{
    public class MainPageViewModel : ObservableObject
    {
        public Database database;
        public List<FirebaseObject<SalonInformationModel>> RequestedList { set; get; }
        private readonly INavigation _navigation;
        public ICommand ProfileCommand { get; private set; }
        public ICommand SelectCardCommand { get; set; }

        FirebaseObject<SalonInformationModel> _selectedItem;
        public FirebaseObject<SalonInformationModel> SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != null)
                    _selectedItem = value;

                OnPropertyChanged();
            }
        }
        
        public MainPageViewModel(INavigation navigation)
        {
            ProfileCommand = new Command(OnProfileTapped);

            _navigation = navigation;
            database = new Database();
            var t = Task.Run(async () =>
            {
                RequestedList = await database.GetSalons();
            });
            t.Wait();

            SelectCardCommand = new Command(SelectCard);
        }

        private async void OnProfileTapped()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UserProfilePage(SelectedItem));
        }

        private async void SelectCard()
        {
            await _navigation.PushAsync(new SalonProfilePage(SelectedItem));
        }
    }
}