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

        private INavigation _navigation;

        public ICommand ProfileCommand { get; private set; }

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
        }

        private async void OnProfileTapped()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UserProfilePage(SelectedItem));
        }

        public async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault();

            if (selectedItem != null)
            {
                await _navigation.PushAsync(new SalonProfilePage((FirebaseObject<SalonInformationModel>)selectedItem));
            }
        }
    }
}