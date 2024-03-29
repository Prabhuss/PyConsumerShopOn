﻿using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Templates
{
    /// <summary>
    /// Order history template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderHistoryTemplate : Grid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderHistoryTemplate"/> class.
        /// </summary>
		public OrderHistoryTemplate()
        {
            InitializeComponent();
        }
    }
}