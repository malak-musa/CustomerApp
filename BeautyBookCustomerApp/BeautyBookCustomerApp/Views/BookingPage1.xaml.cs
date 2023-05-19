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
    public partial class BookingPage1 : ContentPage
    {
        readonly FirebaseObject<SalonInformationModel> Details;
        public int serviceNumber = 0;
        public List<string> serviceList = new List<string>();

        public BookingPage1(FirebaseObject<SalonInformationModel> details)
        {
            BindingContext = new BookingPage1ViewModel { SalonDetails = details };
            Details = details;
            InitializeComponent();
        }

        private void PlusButtonClicked(object sender, EventArgs e)
        {
            serviceNumber++;
            serviceNumLabel.Text = serviceNumber.ToString();

            if (serviceNumber == 1)
            {
                serviceList.Add(serviceName.Text);
            }
        }

        private void MinusButtonClicked(object sender, EventArgs e)
        {
            if (serviceNumber >= 1)
            {
                serviceNumber--;
                serviceNumLabel.Text = serviceNumber.ToString();
            }
            if (serviceNumber == 0)
            {
                serviceList.Remove(serviceName.Text);
            }
        }

        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            if(serviceList.Count == 0)
            {   
                await Application.Current.MainPage.DisplayAlert("sorry", "please select service", "ok");

                return;
            }
            await Navigation.PushAsync(new BookingPage2(serviceList, Details));
        }
    }
}