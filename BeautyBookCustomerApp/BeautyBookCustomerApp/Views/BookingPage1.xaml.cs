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
        public BookingPage1()
        {
            InitializeComponent();

        }
        private bool isLabelClicked = false;
        private void OnLabelTapped(object sender, EventArgs e)
        {
            var label = (Label)sender;

            if (!isLabelClicked)
            {
                label.Text = "+";
                isLabelClicked = true;
            }
            else
            {
                label.Text = "-";
                isLabelClicked = false;
            }
        }
        private bool isButtonClicked = false;


        private void OnButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (!isButtonClicked)
            {
                button.Text = "+";
                isButtonClicked = true;
            }
            else
            {
                button.Text = "-";
                isButtonClicked = false;
            }
        }

        public int serviceNumber = 0;
        public List<string> serviceList = new List<string>();

        private void plusButtonClicked(object sender, EventArgs e)
        {
            serviceNumber++;
            serviceNumLabel.Text = serviceNumber.ToString();
            if (serviceNumber == 1)
            {
                serviceList.Add(serviceName.Text);
            }
        }

        private void minusButtonClicked(object sender, EventArgs e)
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
            await Navigation.PushAsync(new BookingPage2(serviceList));
        }
    }
}