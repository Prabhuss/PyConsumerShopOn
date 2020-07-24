using PyConsumerApp.DataService;
using PyConsumerApp.Models;
using PyConsumerApp.ViewModels.Catalog;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using PyConsumerApp.DataService;
using System;

namespace PyConsumerApp.Views.Catalog
{
    /// <summary>
    /// The Category Tile page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryTilePage
    {
        //private CategoryPageViewModel vm;
        private SubCategoryPageViewModel vm;
        private string Latitude;
        private string Longitude;
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryTilePage" /> class.
        /// </summary>
        public CategoryTilePage()
        {
            InitializeComponent();
            //vm = new CategoryPageViewModel();
            vm = new SubCategoryPageViewModel();
            this.BindingContext = vm;
            new Task(async () => {
                await populateData();
            }).Start();
        }
        async private Task populateData()
        {
           // ObservableCollection<Category> categories = await CategoryDataService.Instance.PopulateData();
            ObservableCollection<SubCategory> categories = await CategoryDataService.Instance.PopulateData();
            if (categories != null)
            {
                vm.Categories = categories;
            }
            try
            {
                var app = App.Current as App;
                Merchantdata MrechantSettingDetails = await CategoryDataService.Instance.GetMerchantSettings("Amount");
                if (MrechantSettingDetails != null)
                {
                    app.MinimumOrderAmount = Double.Parse(MrechantSettingDetails.SettingValue);
                    bool DistanceCalculated = await DistanceCheck();
                    if (!DistanceCalculated)
                    {
                        await Task.Delay(2000);
                        //await DisplayAlert("Location Error(101)", "Unable to access Location", "Ok");
                    }
                }
            }
            catch (Exception e)
            {
                string a = e.Message;
                await Task.Delay(1000);
                //await DisplayAlert("Error", "Somthing went wrong while accessing Merchant details", "Ok");
            }

        }

        async private Task<bool> DistanceCheck()
        {
            var app = App.Current as App;
            bool CordinatesFlag = await getCordinatesAsync();
            if (CordinatesFlag)
            {
                double Distance = Double.Parse(await CategoryDataService.Instance.CalculateDistance(Latitude, Longitude));
                if (Distance > 0)
                {
                    Merchantdata MrechantSettingDetails = await CategoryDataService.Instance.GetMerchantSettings("Distance");
                    if (MrechantSettingDetails != null)
                    {
                        if ((Double.Parse(MrechantSettingDetails.SettingValue) - Distance) < 0)
                        {
                            await DisplayAlert("Message", MrechantSettingDetails.SettingMessage, "Ok");
                        }
                        return true;
                    }
                }
            }
                return false;
        }

        public async Task<bool> getCordinatesAsync()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    Latitude = location.Latitude.ToString();
                    Longitude = location.Longitude.ToString();
                    return true;
                }
                else
                {
                    await Task.Delay(2000);
                    //await DisplayAlert("Location Error(102)", "We are facing problem in accessing your Current location", "Ok");
                    return false;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await Task.Delay(2000);
                //await DisplayAlert("Location Error(103)", "We are facing problem in accessing your Current location", "Ok");
                return false;
            }
            catch (PermissionException pEx)
            {
                await Task.Delay(2000);
                //await DisplayAlert("Location Error(104)", "We are facing problem in accessing your Current location", "Ok");
                return false;
            }
            catch (System.Exception ex)
            {
                await Task.Delay(2000);
                //await DisplayAlert("Location Error(105)", "We are facing problem in accessing your Current location", "Ok");
                return false;
            }

        }
    }
}