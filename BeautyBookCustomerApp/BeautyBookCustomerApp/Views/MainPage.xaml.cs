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

            //BindingContext = new MainPageViewModel();
            var viewModel = new MainPageViewModel(Navigation);
            BindingContext = viewModel;
            InitializeComponent();
        }

        private async void OnProfileTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserProfilePage());
        }



        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    var viewModel = BindingContext as MainPageViewModel;
    viewModel?.CollectionView_SelectionChanged(sender, e);
}

    }
}