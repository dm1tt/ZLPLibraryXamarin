using System.Net;
using Xamarin.Forms;
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
	}
}