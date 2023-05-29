using System;
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
         #region       
        

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
     
        public int bookId
        {
            get { return _shortbook.bookId; }
            set
            {

                    _shortbook.bookId = value;
                    OnPropertyChanged(nameof(bookId));

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
                    OnPropertyChanged(nameof(bookName));
                }
            }
        }

        private string _instock = "";
        public string inStock
        {
            get {
                return _instock;
            }
            set
            {
                if (Boolean.Parse(value))
                    _instock =  "В наличии";
                else
                    _instock =  "Нет в наличии";
                OnPropertyChanged(nameof(inStock));
            }
        }
        public string author
        {
            get { return _shortbook.author; }
            set
            {
                _shortbook.author = value;
                OnPropertyChanged(nameof(author));
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
                    OnPropertyChanged(nameof(yearOfPublishing));
                }
            }
        }
        public ObservableCollection<ShortBook> GetSearchResults(string queryString)
        {
            var normalizedQuery = queryString?.ToLower() ?? null;
            return new ObservableCollection<ShortBook>(AllShortBooks.Where(n => n.bookName.Contains(normalizedQuery)));
        }
        #endregion

        private ShortBook _shortbook;
        private readonly ProductService _productService;
        private ObservableCollection<ShortBook> _books;
        private ObservableCollection<ShortBook> _searchResults;

        public ICommand CancelngSearch => new Command<string>((string query) =>
        {
            SearchResults = GetSearchResults("");
        });
        public ICommand PerformSearch => new Command<string>((string query) =>
        {
            SearchResults = GetSearchResults(query);
        });
        public MainPageViewModel()
        {
            Task.Run(() => LoadAllShortBooks());
            _productService = new ProductService();
            _shortbook = new ShortBook();
            _books = new ObservableCollection<ShortBook>();
            AllShortBooks = _books;
            _searchResults = AllShortBooks;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private async Task LoadAllShortBooks()
        {
            if (AllShortBooks != null)
            {
                AllShortBooks.CollectionChanged -= OnCollectionChanged;
            }
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