using BeautyBookCustomerApp.Models;
using BeautyBookCustomerApp.ViewModel;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeautyBookCustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainPageViewModel();

            InitializeComponent();
        }

        private async void OnProfileTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserProfilePage());
        }

        private async void VisitButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SalonProfilePage());
        }

        async void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {

            var collectionView = sender as CollectionView;
            var selectedItem = e.CurrentSelection.FirstOrDefault();

            if (selectedItem != null)
            {

                await Navigation.PushAsync(new SalonProfilePage((FirebaseObject<SalonInformationModel>)selectedItem));



            }

        }
    }
}