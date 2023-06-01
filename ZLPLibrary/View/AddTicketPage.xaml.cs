using System;
using Xamarin.Forms;
using ZLPLibrary.ViewModel;

namespace ZLPLibrary.View
{
    public partial class AddTicketPage : ContentPage
	{
		public AddTicketPage (int bookId)
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new AddTicketPageViewModel(bookId);
        }
        async void OnTappedToBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}