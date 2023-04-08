using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BeautyBookCustomerApp.Views;

namespace BeautyBookCustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SalonProfilePage : ContentPage
    {
        public class LabelData
        {
            public string LabelText { get; set; }
        }

        public SalonProfilePage()
        {
            InitializeComponent();

        }

        private async void AppointmentButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookingPage1());
        }


    }
}