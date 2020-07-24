using Plugin.Connectivity;
using PyConsumerApp.Models.History;
using PyConsumerApp.ViewModels.History;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.History
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderSummary : ContentPage
    {
        OrderSummaryViewModel viewModel;
        public OrderSummary()
        {
            InitializeComponent();
        }
        public OrderSummary(CustomerInvoiceDatum InvoiceDetails, ObservableCollection<InvocieLineItem> LineitemFromCloud)
        {
            InitializeComponent();
            if (CrossConnectivity.Current.IsConnected)
            {

            }
            else
            {
                App.Current.MainPage.DisplayAlert("Alert", "Check Your Internet Connectivity", "OK");
            }
            BindingContext = viewModel = new OrderSummaryViewModel(InvoiceDetails, LineitemFromCloud);
        }
    }
}