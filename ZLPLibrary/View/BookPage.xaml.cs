using System;
using Xamarin.Forms;
using ZLPLibrary.ViewModel;

namespace ZLPLibrary.View
{
	public partial class BookPage : ContentPage
	{
        public BookPage (int bookId)
		{
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new BookPageViewModel(bookId);
        }
        private async void OnTappedAddTicketPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTicketPage());
        }
        async void OnTappedToBack(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
        }
    }
}