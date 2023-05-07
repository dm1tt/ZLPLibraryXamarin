using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Xamarin.Forms;
using ZLPLibrary.Model;
using ZLPLibrary.Service;
using ZLPLibrary.View;

namespace ZLPLibrary.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ShortBook _shortbook;
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly ProductService _productService;
        public List<ShortBook> AllShortBooks { get; set; }

        public MainPageViewModel()
        {
            _productService = new ProductService();
            _shortbook = new ShortBook();
            AllShortBooks = new List<ShortBook>();
            LoadAllShortBooks();
        }
        public int bookId
        {
            get { return _shortbook.bookId; }
            set
            {
                if (_shortbook.bookId != value)
                {
                    _shortbook.bookId = value;
                    OnPropertyChanged("ProductImage");
                }
            }
        }
        public string ProductImage
        {
            get { return _shortbook.ProductImage; }
            set
            {
                if (_shortbook.ProductImage != value)
                {
                    _shortbook.ProductImage = value;
                    OnPropertyChanged("ProductImage");
                }
            }
        }
        public string bookName
        {
            get { return _shortbook.bookName; }
            set
            {
                if (_shortbook.bookName != value)
                {
                    _shortbook.bookName = value;
                    OnPropertyChanged("ProductName");
                }
            }
        }
        public bool inStock
        {
            get { return _shortbook.inStock; }
            set
            {
                if (_shortbook.inStock != value)
                {
                    _shortbook.inStock = value;
                    OnPropertyChanged("InStock");
                }
            }
        }
        public string author
        {
            get { return _shortbook.author; }
            set
            {
                if (_shortbook.author != value)
                {
                    _shortbook.author = value;
                    OnPropertyChanged("Author");
                }
            }
        }
        public string yearOfPublishing
        {
            get { return _shortbook.yearOfPublishing; }
            set
            {
                if (_shortbook.yearOfPublishing != value)
                {
                    _shortbook.yearOfPublishing = value;
                    OnPropertyChanged("YearOfPublishing");
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        private async void LoadAllShortBooks()
        {
            AllShortBooks = await _productService.GetAllShortBooksAsync();
        }
    }
}