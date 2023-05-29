using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using ZLPLibrary.Model;
using ZLPLibrary.Service;

namespace ZLPLibrary.ViewModel
{
    public class AddBookPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly ProductService _productService;
        private readonly FullBook _fullBook;
        public FullBook FullBook { get; set; }
        public ICommand AddNewBookCommand { get;}
        
        #region
        public string bookName
        {
            get { return _fullBook.bookName; }
            set
            {
                if (_fullBook.bookName != value)
                {
                    _fullBook.bookName = value;
                    OnPropertyChanged(nameof(bookName));
                }
            }
        }
        public string authors
        {
            get { return _fullBook.authors; }
            set
            {
                if (_fullBook.authors != value)
                {
                    _fullBook.authors = value;
                    OnPropertyChanged(nameof(authors));
                }
            }
        }
        public string typeId
        {
            get { return _fullBook.typeId; }
            set
            {
                if (_fullBook.typeId != value)
                {
                    _fullBook.typeId = value;
                    OnPropertyChanged(nameof(typeId));
                }
            }
        }
        public int? numberOfPage
        {
            get { return _fullBook.numberOfPage; }
            set
            {
                if (_fullBook.numberOfPage != value)
                {
                    _fullBook.numberOfPage = value;
                    OnPropertyChanged(nameof(numberOfPage));
                }
            }
        }
        public bool inStock
        {
            get { return _fullBook.inStock = true; }
            set { _fullBook.inStock = true;}
        }
        public string publishingHouse
        {
            get { return _fullBook.publishingHouse; }
            set
            {
                if (_fullBook.publishingHouse != value)
                {
                    _fullBook.publishingHouse = value;
                    OnPropertyChanged(nameof(publishingHouse));
                }
            }
        }
        public string yearOfPublication
        {
            get { return _fullBook.yearOfPublication; }
            set
            {
                if (_fullBook.yearOfPublication != value)
                {
                    _fullBook.yearOfPublication = value;
                    OnPropertyChanged(nameof(yearOfPublication));
                }
            }
        }
        #endregion
        public AddBookPageViewModel()
        {
            _productService = new ProductService();
            _fullBook = new FullBook();
            FullBook = _fullBook;
            AddNewBookCommand = new Command(AddNewBook);
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public int newBookId;
        private async void AddNewBook()
        {
            newBookId = await _productService.PostNewBookAsync(FullBook);
        }
    }
}
