
using Plugin.Connectivity;
using Syncfusion.XForms.Buttons;
using System;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Transaction
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentView //: ContentPage
    {
        public PaymentView()
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

        private void PWC_StateChanged(object sender, StateChangedEventArgs e)
        {

        }
    }
}