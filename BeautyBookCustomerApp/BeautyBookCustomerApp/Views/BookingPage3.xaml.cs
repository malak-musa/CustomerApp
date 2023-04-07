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
    
        public BookingPage3(int count)
        {
            InitializeComponent();
            Label countValue = this.FindByName<Label>("labelData");
            countValue.Text = count.ToString();

        }


        private async void SwipeGestureRecognizer_Swiped_1(object sender, SwipedEventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}