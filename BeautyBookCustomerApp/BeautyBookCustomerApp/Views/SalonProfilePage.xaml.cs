using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BeautyBookCustomerApp.Views;
using BeautyBookCustomerApp.Models;
using Firebase.Database;
using BeautyBookCustomerApp.ViewModel;

namespace BeautyBookCustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SalonProfilePage : ContentPage
    {
        FirebaseObject<SalonInformationModel> Deatails { set; get; }

        public class LabelData
        {
            public string LabelText { get; set; }
        }

        public SalonProfilePage(FirebaseObject<SalonInformationModel> details)
        {
            Deatails = details;
            BindingContext = new SalonProfileViewModel { SalonDetails = details };

            InitializeComponent();
        }

        private async void AppointmentButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookingPage1(Deatails));
        }
    }
}