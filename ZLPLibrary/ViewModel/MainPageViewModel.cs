using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using ZLPLibrary.Model;
using ZLPLibrary.Service;

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
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        private async Task LoadAllShortBooks()
        {
            AllShortBooks = await _productService.GetAllShortBooksAsync();
        }
    }
}