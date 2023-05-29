using System;
using Xamarin.Forms;
using ZLPLibrary.Model;
using ZLPLibrary.View;
using ZLPLibrary.ViewModel;

namespace ZLPLibrary
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private async void OnTapped(object sender, EventArgs e)
        {
            var frame = sender as Frame;
            var book = frame.BindingContext as ShortBook;
            await Navigation.PushAsync(new BookPage(book.bookId));
        }
      
        private async void OnTappedAddNewBook (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBookPage());
        }
    }
}
