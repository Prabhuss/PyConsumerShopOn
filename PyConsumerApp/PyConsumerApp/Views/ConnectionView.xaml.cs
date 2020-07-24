﻿
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectionView : StackLayout //: ContentPage
    {
        public ConnectionView()
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