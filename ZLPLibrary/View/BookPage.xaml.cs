using System;
using Xamarin.Forms;
using ZLPLibrary.ViewModel;

namespace ZLPLibrary.View
{
	public partial class BookPage : ContentPage
	{
        public int BookId;
        public BookPage (int bookId)
		{
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BookId = bookId;
            BindingContext = new BookPageViewModel(BookId);
        }
        private async void OnTappedAddTicketPage(object sender, EventArgs e)
        { 
            await Navigation.PushAsync(new AddTicketPage(BookId));
        }
        async void OnTappedToBack(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
        }
    }
}