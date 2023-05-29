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
		async void OnTappedToBack(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
        }
    }
}