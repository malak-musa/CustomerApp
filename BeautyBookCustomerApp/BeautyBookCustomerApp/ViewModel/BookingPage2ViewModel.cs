using BeautyBookCustomerApp.Models;
using BeautyBookCustomerApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BeautyBookCustomerApp.ViewModel
{
    public class BookingPage2ViewModel
    {
        private async void OnShowServices(object obj)
        {
            BookingModelPage3 serviceModel = (BookingModelPage3)obj;
            await Application.Current.MainPage.Navigation.PushModalAsync(new BookingPage3("2002/2/22","3:30", "idest"));
        }
    }
}
