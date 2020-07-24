
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Transaction
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressEditPage : ContentPage
    {
        public AddressEditPage()
        {
            InitializeComponent();
            if (CrossConnectivity.Current.IsConnected)
            {

            }
            else
            {
                App.Current.MainPage.DisplayAlert("Alert", "Check Your Internet Connectivity", "OK");
            }
        }
    }
}