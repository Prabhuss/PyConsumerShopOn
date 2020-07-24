using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Bookmarks
{
    /// <summary>
    /// The PriceDetail View.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PriceDetailView
    {
        /// <summary>
        /// Gets or sets the ActionTextProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty ActionTextProperty =
            BindableProperty.Create(nameof(ActionText), typeof(string), typeof(PriceDetailView));

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceDetailView" /> class.
        /// </summary>
        public PriceDetailView()
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

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the Action Text.
        /// </summary>
        public string ActionText
        {
            get { return (string)GetValue(ActionTextProperty); }
            set { this.SetValue(ActionTextProperty, value); }
        }

        #endregion
    }
}