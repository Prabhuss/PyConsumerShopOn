
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Orders : ContentPage
    {
        public Orders()
        {
            InitializeComponent();
            if (CrossConnectivity.Current.IsConnected)
            {

            }
            else
            {
                App.Current.MainPage.DisplayAlert("Alert", "Check Your Internet Connectivity", "OK");
            }
            //BindingContext = new OrdersViewModel();
        }
    }
    /* public class ExtendedListView : SfListView
    {
        VisualContainer container;
        public ExtendedListView()
        {
            container = this.VisualContainer;

            container.PropertyChanged += Container_PropertyChanged;
        }

        private void Container_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Height))
            {
                var extent = (double)container.GetType().GetRuntimeProperties().FirstOrDefault(container => container.Name == "TotalExtent").GetValue(container);
                this.HeightRequest = extent;
            }
        }
    }
    */
}