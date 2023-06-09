﻿using System;
using Xamarin.Forms;
using ZLPLibrary.Service;
using ZLPLibrary.ViewModel;

namespace ZLPLibrary.View
{
    public partial class AddBookPage : ContentPage
	{
        public AddBookPage ()
        {
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new AddBookPageViewModel();
        }
        async void OnTappedToBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}