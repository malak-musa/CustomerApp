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
    public partial class BookingPage2 : ContentPage
    {
        public BookingPage2()
        {
            InitializeComponent();
        }

        private void SelectTime(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundColor = Color.White;
            button.TextColor = Color.Black;
            button.BorderWidth = 1;
            button.BorderColor = Color.DarkOliveGreen;
        }
    }
}