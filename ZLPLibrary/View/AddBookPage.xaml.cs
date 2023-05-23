using System;
using Xamarin.Forms;
using ZLPLibrary.Service;
using ZLPLibrary.ViewModel;

namespace ZLPLibrary.View
{
    public partial class AddBookPage : ContentPage
	{
        private readonly ProductService _productService;
        public AddBookPage ()
        {
			InitializeComponent ();
            _productService = new ProductService ();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new AddBookPageViewModel();
        }
        async void OnTappedToBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Completed(object sender, EventArgs e)
        {
        }
    }
}