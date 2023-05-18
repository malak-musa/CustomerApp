using BeautyBookCustomerApp.Models;
using BeautyBookCustomerApp.ViewModel;
using BeautyBookCustomerApp.ViewModels;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeautyBookCustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfilePage : ContentPage
    {
        FirebaseObject<SalonInformationModel> Deatails { set; get; }

        public UserProfilePage(FirebaseObject<SalonInformationModel> details)
        {
            BindingContext = new UserProfileViewModel { SalonDetails = details };
            Deatails = details;
            InitializeComponent();
        }

        private async void Logout_clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopToRootAsync();
            Application.Current.MainPage = new NavigationPage(new LoginPage());
            SecureStorage.RemoveAll();
        }
    }
}