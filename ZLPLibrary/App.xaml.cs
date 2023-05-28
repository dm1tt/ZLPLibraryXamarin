using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using ZLPLibrary.Model;
using ZLPLibrary.Service;
using ZLPLibrary.View;
using ZLPLibrary.ViewModel;

namespace ZLPLibrary;

public partial class App : Application
{
    static public ObservableCollection<ShortBook> ShortBooks { get; set; }

    private readonly ProductService _productService;
    public App()
    {
        InitializeComponent();
        _productService = new ProductService();
        MainPage = new NavigationPage(new SplashPage());
    }

    protected override async void OnStart()
    {
        ShortBooks = await _productService.GetAllShortBooksAsync();
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
}

