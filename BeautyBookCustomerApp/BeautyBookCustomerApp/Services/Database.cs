using BeautyBookCustomerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Newtonsoft.Json;
using Nest;
using System.Linq;
using Xamarin.Essentials;
using BeautyBookCustomerApp.ViewModel;
using BeautyBookCustomerApp.Views;
using Firebase.Auth.Providers;
using Firebase.Auth;
using Firebase.Database.Query;
using System.Diagnostics;
using System.Collections.ObjectModel;
using BeautyBookAdminApp.Models;
using Xamarin.Forms;

namespace BeautyBookCustomerApp.Services
{
    public class Database
    {
        readonly FirebaseClient firebaseClient = new FirebaseClient("https://beautybookapp-a44e5-default-rtdb.europe-west1.firebasedatabase.app/");
        private const string FirebaseApiKey = "AIzaSyA37bTpBm27kjiHDuf5tigFwCmVsxmEYsY";
        private const string AuthDomain = "beautybookapp-a44e5.firebaseapp.com";
        private readonly FirebaseAuthClient CustomerAuth;

        public Database()
        {
            var config = new FirebaseAuthConfig
            {
                ApiKey = FirebaseApiKey,
                AuthDomain = AuthDomain,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            };
            CustomerAuth = new FirebaseAuthClient(config);
        }

        public async Task<bool> SaveSalonInfo(CustomerModel salon)
        {
            var data = await firebaseClient.Child(nameof(SalonProfileViewModel)).PostAsync(JsonConvert.SerializeObject(salon));

            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> SaveCustomerInfo(CustomerModel salon)
        {
            var data = await firebaseClient.Child(nameof(CustomerModel)).PostAsync(JsonConvert.SerializeObject(salon));
            
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;

            }
            return false;
        }

        public async Task SingUp(AuthModel authModel, string email, string password)
        {
            try
            {                
                var userCredential = await CustomerAuth.CreateUserWithEmailAndPasswordAsync(email, password);
                authModel.UserId = userCredential.User.Uid;

                await firebaseClient.Child("CustomerModel").PostAsync<AuthModel>(authModel);
                await SecureStorage.SetAsync("oauth_token", userCredential.User.Uid);

                if (userCredential.User.Uid != null)
                {
                    App.Current.MainPage = new NavigationPage(new MainPage());
                }
            }
            catch (FirebaseAuthException ex)
            {
                if (ex.Reason == AuthErrorReason.InvalidEmailAddress)
                {
                    await App.Current.MainPage.DisplayAlert("Authentication Error", ex.Reason.ToString(), "OK");
                }

                else if (ex.Reason == AuthErrorReason.EmailExists)
                {
                    await App.Current.MainPage.DisplayAlert("Authentication Error", ex.Reason.ToString(), "OK");
                }

                else if (ex.Reason == AuthErrorReason.WeakPassword)
                {
                    await App.Current.MainPage.DisplayAlert("Authentication Error", ex.Reason.ToString(), "OK");

                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Authentication Error", ex.Message.ToString(), "OK");
            }
        }

        public async Task SingIn(string email, string password)
        {
            try
            {
                var userCredential = await CustomerAuth.SignInWithEmailAndPasswordAsync(email, password);
                string token = userCredential.User.Uid;

                await SecureStorage.SetAsync("oauth_token", token);

                if (token != null)
                {
                    App.Current.MainPage = new NavigationPage(new MainPage());
                }
            }
            catch (FirebaseAuthException ex)
            {
                if (ex.Reason == AuthErrorReason.UnknownEmailAddress)
                {
                    await App.Current.MainPage.DisplayAlert("Authentication Error", ex.Reason.ToString(), "OK");
                }
                else if (ex.Reason == AuthErrorReason.EmailExists)
                {
                    await App.Current.MainPage.DisplayAlert("Authentication Error", ex.Reason.ToString(), "OK");
                }
                else if (ex.Reason == AuthErrorReason.WrongPassword)
                {
                    await App.Current.MainPage.DisplayAlert("Authentication Error", ex.Reason.ToString(), "OK");
                }
                await App.Current.MainPage.DisplayAlert("Authentication Error", ex.Reason.ToString(), "OK");

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Authentication Error", ex.Message.ToString(), "OK");
            }
        }
        
        public async Task<AuthModel>GetUserInfo(string userId)
        {
            var usersData=await firebaseClient.Child("CustomerModel").OnceAsync<AuthModel>();

            return usersData.Where(el=>el.Object.UserId == userId).FirstOrDefault().Object; 
        }
        
        public async Task<List<FirebaseObject<SalonInformationModel>>> GetSalons()
        {
            var requestedList = await firebaseClient.Child("SalonProfile").OnceAsync<SalonInformationModel>();

            return requestedList.ToList();
        }

        public async Task<bool> DeleteBooking(FirebaseObject<BookingModel> booking)
        {
            try
            {
                var bookingRef = firebaseClient.Child("BookingModel").Child(booking.Key);
                await bookingRef.DeleteAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting booking: {ex.Message}");

                return false;
            }
        }

        public async Task<bool> SaveAppointmentInformation(BookingModel bookingInfo)
        {
            var data = await firebaseClient.Child(nameof(BookingModel)).PostAsync(JsonConvert.SerializeObject(bookingInfo));

            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }

            return false;
        }

        public async Task<List<FirebaseObject<BookingModel>>> GetBooking(string userId)
        {
            var requestedList = await firebaseClient.Child("BookingModel").OnceAsync<BookingModel>();

            return requestedList.Where(el => el.Object.UserId == userId).ToList();
        }

        public async Task<bool> EditBookingStatus(string objectId, string newStatus)
        {
            try
            {
                await firebaseClient.Child("BookingModel").Child(objectId).Child("Status").PutAsync<string>(newStatus);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ObservableCollection<CustomerModel> GetSalonProfile()
        {
            var salon = firebaseClient.Child("SalonProfile").AsObservable<CustomerModel>().AsObservableCollection();
            
            return salon;
        }

        /*public async Task<List<FirebaseObject<SalonInformationModel>>> GetSalonServices(string salonId)
        {
            if (string.IsNullOrEmpty(salonId))
            {
                throw new ArgumentException("Salon ID cannot be null or empty.", nameof(salonId));
            }

            var salonServices = await firebaseClient
                .Child("SalonProfile")
                .Child(salonId)
                .Child("Services")
                .OnceAsync<SalonInformationModel>();

            return salonServices.ToList();
        }*/
        public async Task<IEnumerable<Service>> GetSalonServices(string salonId)
        {
            var servicesObj = await firebaseClient.Child("SalonProfile").Child(salonId).Child("Services").OnceAsListAsync<Service>();

            return servicesObj.Select(el => el.Object);
        }
    }
}