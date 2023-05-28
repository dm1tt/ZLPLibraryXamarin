using Xamarin.Forms;
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

    }
}