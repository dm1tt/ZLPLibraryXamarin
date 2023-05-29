using System;
using Xamarin.Forms;
using ZLPLibrary.Model;
using ZLPLibrary.ViewModel;

namespace ZLPLibrary.View
{
    public partial class PersonListPage : ContentPage
    {
        public PersonListPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new PersonListPageViewModel();
        }
        private async void OnTapped(object sender, EventArgs e)
        {
            var frame = sender as Frame;
            var reader = frame.BindingContext as Reader;
            await Navigation.PushAsync(new ReaderPage(reader));
        }
        private async void OnTappedAddNewReader(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddNewPersonPage());
        }
    }
}