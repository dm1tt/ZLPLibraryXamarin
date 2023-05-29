using System;
using Xamarin.Forms;
using ZLPLibrary.ViewModel;

namespace ZLPLibrary.View
{
    public partial class AddNewPersonPage : ContentPage
	{
		public AddNewPersonPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        async void OnTappedToBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}