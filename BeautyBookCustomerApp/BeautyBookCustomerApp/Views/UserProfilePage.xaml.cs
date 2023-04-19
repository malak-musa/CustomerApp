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
    public partial class UserProfilePage : ContentPage
    {
        public UserProfilePage()
        {
            InitializeComponent();
        }
        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Grid grid = (Grid)FindByName("grid1");
            grid.Children.Clear();
        }
        private async void SwipeGestureRecognizer_Swiped_1(object sender, SwipedEventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}