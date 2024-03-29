﻿using Plugin.Connectivity;
using PyConsumerApp.ViewModels.ErrorandEmpty;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.ErrorAndEmpty
{
    /// <summary>
    /// Page to show the empty cart
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmptyView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyView" /> class.
        /// </summary>
        public EmptyView(bool IsCartPage, string headerText, string contentText, string imagepath = "EmptyCart.svg")
        {
            InitializeComponent();
            BindingContext = new EmptyCartPageViewModel(IsCartPage, headerText, contentText, imagepath);
        }

        /// <summary>
        /// Invoked when view size is changed.
        /// </summary>
        /// <param name="width">The Width</param>
        /// <param name="height">The Height</param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width > height)
            {
                if (Device.Idiom == TargetIdiom.Phone) ErrorImage.IsVisible = false;
            }
            else
            {
                ErrorImage.IsVisible = true;
            }
        }
    }
}