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
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new MainPageViewModel();
        }

    }
}
