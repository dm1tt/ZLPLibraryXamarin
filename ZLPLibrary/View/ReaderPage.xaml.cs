using System;
using Xamarin.Forms;
using ZLPLibrary.Model;
using ZLPLibrary.ViewModel;

namespace ZLPLibrary.View
{
    public partial class ReaderPage : ContentPage
    {
        public ReaderPage(Reader reader)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new ReaderPageViewModel(reader);
        }
        async void OnTappedToBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}