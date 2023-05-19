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
            var viewModel = new MainPageViewModel(Navigation);
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}