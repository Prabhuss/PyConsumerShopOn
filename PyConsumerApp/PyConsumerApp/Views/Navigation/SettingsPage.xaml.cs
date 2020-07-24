using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Navigation
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
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