using System;
using System.ComponentModel;
using ZLPLibrary.Model;
using ZLPLibrary.Service;

namespace ZLPLibrary.ViewModel
{
    public class BookPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly ProductService _productService;
        private FullBook _fullBook;
        private ReaderTicketUsers _readerTicketUsers;
        private Reader _reader;
        public FullBookResponse FullBookResponse { get; set; }
        public int BookId { get; set; }
        public BookPageViewModel(int bookId)
        {
            _productService = new ProductService();
            BookId = bookId;
            LoadFullBookAsync(bookId);
        }
        public string typeId
        {
            get { return _fullBook.typeId; }
            set
            {
                if(_fullBook.typeId != value)
                {
                    _fullBook.typeId = value;
                    OnPropertyChanged(nameof(typeId));
                }
            }
        }
        public string bookName
        {
            get { return _fullBook.bookName; }
            set
            {
                if( _fullBook.bookName != value)
                {
                    _fullBook.bookName = value;
                    OnPropertyChanged(nameof(bookName));
                }
            }
        }
        public bool inStock
        {
            get { return _fullBook.inStock; }
            set
            {
                if (_fullBook.inStock != value) 
                {
                    _fullBook.inStock = value;
                    OnPropertyChanged(nameof(inStock));
                }
            }
        }
        public string authors
        {
            get { return _fullBook.authors; }
            set
            {
                if(_fullBook.authors != value)
                {
                    _fullBook.authors = value;
                    OnPropertyChanged(nameof(authors));
                }
            }
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
        public int id
        {
            get { return _readerTicketUsers.id; }
            set
            {
                if (_readerTicketUsers.id != value)
                {
                    _readerTicketUsers.id = value;
                    OnPropertyChanged(nameof(id));
                }
            }
        }
        public string receivingDate
        {
            get { return _readerTicketUsers.receivingDate; }
            set
            {
                if (_readerTicketUsers.receivingDate != value)
                {
                    _readerTicketUsers.receivingDate = value;
                    OnPropertyChanged(nameof(receivingDate));
                }
            }
        }
        public string returnDate
        {
            get { return _readerTicketUsers.returnDate; }
            set
            {
                if (_readerTicketUsers.returnDate != value)
                {
                    _readerTicketUsers.returnDate = value;
                    OnPropertyChanged(nameof(returnDate));
                }
            }
        }
        public int readerId
        {
            get { return _reader.readerId; }
            set
            {
                if (_reader.readerId != value)
                {
                    _reader.readerId = value;
                    OnPropertyChanged(nameof(readerId));
                }
            }
        }
        public string firstName
        {
            get { return _reader.firstName; }
            set
            {
                if (_reader.firstName != value)
                {
                    _reader.firstName = value;
                    OnPropertyChanged(nameof(firstName));
                }
            }
        }
        public string secondName
        {
            get { return _reader.secondName; }
            set
            {
                if (_reader.secondName != value)
                {
                    _reader.secondName = value;
                    OnPropertyChanged(nameof(secondName));
                }
            }
        }
        public string thirdName
        {
            get { return _reader.thirdName; }
            set
            {
                if (_reader.thirdName != value)
                {
                    _reader.thirdName = value;
                    OnPropertyChanged(nameof(thirdName));
                }
            }
        }
        public string ticketNumber
        {
            get { return _reader.ticketNumber; }
            set
            {
                if (_reader.ticketNumber != value)
                {   
                    _reader.ticketNumber = value;
                    OnPropertyChanged(nameof(ticketNumber));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        private async void LoadFullBookAsync(int bookId)
        {
            FullBookResponse = await _productService.GetFullBookAsync(bookId);
        }
    }
}
