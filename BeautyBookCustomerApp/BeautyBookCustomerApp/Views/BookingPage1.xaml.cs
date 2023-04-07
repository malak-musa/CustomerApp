using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeautyBookCustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingPage1 : ContentPage
    {
        private int count = 0;
        public BookingPage1()
        {
            InitializeComponent();
        }
        private async void OnIncreaseButtonClicked(object sender, EventArgs e)
        {
            count++;
            await Navigation.PushAsync(new BookingPage3(count));

        }
    }
}