using PyConsumerApp.DataService;
using PyConsumerApp.Models;
using PyConsumerApp.ViewModels;
using PyConsumerApp.Views.Forms;
using PyConsumerApp.Views.Navigation;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Collections.Generic;
using Plugin.Connectivity;

namespace PyConsumerApp
{
    public partial class App : Application
    {
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
        public static string CategoryPicUrl { get; } = "https://getpytaskintg.blob.core.windows.net/productpics";//category images
        public static string product_url { get; } = "https://getpytaskintg.blob.core.windows.net/productpics"; //product image

        public static string profileImage { get; } = "https://getpytaskintg.blob.core.windows.net/productpics/userimage.PNG";


        private const string logIn_Status = "logInStatus";
        private const string securityAccessKey = "securityAccessKey";
        private const string user_PhoneNumber  = "UserPhoneNumber";
        private const string minimumOrderAmount = "minimumOrderAmount";
        //hardcodeMerchantID
        private const string merchantid = "1";

        private static Label labelScreen;
        private static bool hasInternet;
        private static Page currentPage;
        private static Timer timer;
        private static bool noInterShow;

        private string _cartItems = "cartitems";

        // private static string user_PhoneNumber { get; set; }// = "UserPhoneNumber";


       public string CartItems
        {
            get
            {
                if (Properties.ContainsKey(_cartItems))
                    return (string)Properties[_cartItems];
                return null;
            }
            set
            {
                Properties[_cartItems] = value;
            }
        }

        public bool IsLoggedIn
        {
            get
            {
                if (Properties.ContainsKey(logIn_Status))
                    return (bool)Properties[logIn_Status];
                return false;
            }
            set
            {
                Properties[logIn_Status] = value;
            }
        }
        public string UserPhoneNumber
        {
            get
            {
                if (Properties.ContainsKey(user_PhoneNumber))
                    return (string)Properties[user_PhoneNumber];
                return null;
            }
            set
            {
                Properties[user_PhoneNumber] = value;
            }
        }
        public double MinimumOrderAmount
        {
            get
            {
                if (Properties.ContainsKey(minimumOrderAmount))
                    return (double)Properties[minimumOrderAmount];
                return 0;
            }
            set
            {
                Properties[minimumOrderAmount] = value;
            }
        }
        public string SecurityAccessKey
        {
            get
            {
                if (Properties.ContainsKey(securityAccessKey))
                    return (string)Properties[securityAccessKey];
                return null;
            }
            set
            {
                Properties[securityAccessKey] = value;
            }
        }
        public string Merchantid
        {
            get
            {
                if (Properties.ContainsKey(merchantid))
                    return (string)Properties[merchantid];
                return null;
            }
            set
            {
                Properties[merchantid] = value;
            }
        }

        public App()
        {
            try
            {
                InitializeComponent();
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjM3MDA4QDMxMzgyZTMxMmUzMFI0YTd3TDF0b2JtUWhJelVlWjRJRGF3Qk1PSDcwUFBBUWxJN3ZITXgybXM9");

                if (!IsLoggedIn)
                {
                    MainPage = new NavigationPage(new LoginPage());
                    BaseViewModel.Navigation = MainPage.Navigation;
                }
                else
                {
                    MainPage = new NavigationPage(new BottomNavigationPage());
                    BaseViewModel.Navigation = MainPage.Navigation;
                }
                DependencyService.Register<MockDataStore>();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while app loading  "+e.Message);
            }
            
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=fea975bc-6fe5-4c13-912a-88aaefdc38a2;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes));

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        /**Checking Internet Connection
         */
        /* public static void StartCheckInternet(Label label, Page page)
        {
            labelScreen = label;
            label.Text = Constants.NoInternetText;
            hasInternet = false;
            currentPage = page;
            if (timer == null)
            {
                timer = new Timer((e) =>
                {
                    CheckInternetOverTime();
                },null,10,(int)TimeSpan.FromSeconds(3).TotalMilliseconds);
            }
        }

        private async static void CheckInternetOverTime()
        {
            var netWorkConnection = DependencyService.Get<INetworkConnection>();
            netWorkConnection.CheckNetworkConnection();
            if (!netWorkConnection.IsConnected)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (hasInternet)
                    {
                        if (!noInterShow)
                        {
                            hasInternet = false;
                            labelScreen.IsVisible = true;
                            await ShowDisplayAlert();
                        }
                    }
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    hasInternet = true;
                    labelScreen.IsVisible = false;
                });
            }
        }

        public static async Task<bool> CheckIfInternet()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            return networkConnection.IsConnected;
        }
        public static async Task<bool> CheckIfInternetAlertAsync()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if(!networkConnection.IsConnected)
            {
                if (!noInterShow)
                {
                    await ShowDisplayAlert();
                }
                return false;
            }
            return true;
        }
        private async static Task ShowDisplayAlert()
        {
            noInterShow = false;
            await currentPage.DisplayAlert("Inernet","Device has no Inernet, please reconnect","OK");
            noInterShow = false;
        }*/
    }
}
