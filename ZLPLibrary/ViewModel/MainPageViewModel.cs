using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZLPLibrary.Model;
using ZLPLibrary.Service;

namespace ZLPLibrary.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ShortBook _shortbook;
        private readonly ProductService _productService;
        private ObservableCollection<ShortBook> _books;
        private ObservableCollection<ShortBook> _searchResults;
        public ICommand PerformSearch => new Command<string>((string query) =>
        {
            SearchResults = GetSearchResults(query);
        });
        public MainPageViewModel()
        {
            _productService = new ProductService();
            _shortbook = new ShortBook();
            _books = new ObservableCollection<ShortBook>();
            FilteredBooks = new ObservableCollection<ShortBook>();
            AllShortBooks = _books;
            _searchResults = AllShortBooks;
            LoadAllShortBooks();
        }
        public ObservableCollection<ShortBook> GetSearchResults(string queryString)
        {
            var normalizedQuery = queryString?.ToLower() ?? "";

            if ( normalizedQuery != "]" )
            {
                return new ObservableCollection<ShortBook>(AllShortBooks.Where(n => n.bookName.Contains(normalizedQuery)));
            }
            else
            {
                _searchResults = AllShortBooks;
                return AllShortBooks;   
            }

        }
        public ObservableCollection<ShortBook> SearchResults
        {
            get
            {
                return _searchResults;
            }
            set
            {
                _searchResults = value;
                OnPropertyChanged(nameof(SearchResults));
            }
        }
        public ObservableCollection<ShortBook> AllShortBooks
        {
            get { return _books; }
            set
            {
                if (_books != value)
                {
                    _books = value;
                    OnPropertyChanged(nameof(AllShortBooks));
                }
            }
        }
      
        private ObservableCollection<ShortBook> _filteredBooks;
        public ObservableCollection<ShortBook> FilteredBooks
        {
            get { return _filteredBooks; }
            set
            {
                if (_filteredBooks != value)
                {
                    _filteredBooks = value;
                    OnPropertyChanged(nameof(FilteredBooks));
                }
            }
        }
        public int bookId
        {
            get { return _shortbook.bookId; }
            set
            {
                if (_shortbook.bookId != value)
                {
                    _shortbook.bookId = value;
                    OnPropertyChanged(nameof(ProductImage));
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
                    OnPropertyChanged(nameof(ProductImage));
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
                    OnPropertyChanged(nameof(ProductImage));
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
                    OnPropertyChanged(nameof(ProductImage));
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
                    OnPropertyChanged(nameof(ProductImage));
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
                    OnPropertyChanged(nameof(ProductImage));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public async Task LoadAllShortBooks()
        {
            AllShortBooks.CollectionChanged -= OnCollectionChanged;
            AllShortBooks.Clear();
            var shortBooks = await _productService.GetAllShortBooksAsync();
            if(shortBooks != null)
            {
                foreach(var book in shortBooks)
                {
                    AllShortBooks.Add(book);
                }
            }
            AllShortBooks.CollectionChanged += OnCollectionChanged;

            OnPropertyChanged(nameof(AllShortBooks));
        }
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(AllShortBooks));
        }

    }   
}