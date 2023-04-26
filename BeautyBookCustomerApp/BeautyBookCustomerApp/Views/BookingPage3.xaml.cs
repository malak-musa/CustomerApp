using BeautyBookCustomerApp.ViewModel;
using Nest;
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
    public partial class BookingPage3 : ContentPage
    {
        public BookingPage3(string time, string date,string userID)
        {
            InitializeComponent();
            BookingPage3ViewModel bookingPage3ViewModel = new BookingPage3ViewModel(time, date, userID);
            BindingContext = new BookingPage3ViewModel(time, date,userID);
        }



        private void ConfirmButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}