using System;
using Xamarin.Forms;


namespace ZLPLibrary.View
{
    public partial class TabbedMainPage : TabbedPage
    {
        public TabbedMainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
    }
}