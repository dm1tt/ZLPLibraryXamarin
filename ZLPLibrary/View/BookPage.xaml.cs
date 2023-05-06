using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZLPLibrary.Model;
using ZLPLibrary.ViewModel;

namespace ZLPLibrary.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookPage : ContentPage
	{
		public BookPage (ShortBook book)
		{
            InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
			BindingContext = new BookPageViewModel(book);
		}
		async void OnTappedToBack(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

    }
}