using System;
using System.Net;
using Xamarin.Forms;
using ZLPLibrary.Model;
using ZLPLibrary.ViewModel;

namespace ZLPLibrary.View
{
    public partial class AddBookPage : ContentPage
	{
        public FullBook fullBook;
        public AddBookPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new AddBookPageViewModel(fullBook);
        }
        async void OnTappedToBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Completed(object sender, EventArgs e)
        {
            fullBook.bookName = bookNameEntry.Text;
            fullBook.authors = authorsEntry.Text;
            fullBook.numberOfPage = Convert.ToInt32(numberOfPageEntry.Text);
            fullBook.publishingHouse = publishingHouseEntry.Text;
            fullBook.yearOfPublication = yearOfPublishingEntry.Text;
        }
    }
}