using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZLPLibrary.Model;
using ZLPLibrary.Service;

namespace ZLPLibrary.ViewModel
{
    public class AddTicketPageViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Reader _reader;
        private ObservableCollection<Reader> _readers;
        private Reader _selectedReader;
        private ReaderService _readerService;
        private ProductService _productService;
        public int BookId { get; set; }
        public ICommand SelectindReaderCommand { get; }
        #region
        public ObservableCollection<Reader> AllReaders
        {
            get
            {
                return _readers;
            }
            set
            {
                _readers = value;
                OnPropertyChanged(nameof(_readers));
            }
        }
        public Reader SelectedReader
        {
            get { return _selectedReader; }
            set
            {
                _selectedReader = value;
                OnPropertyChanged(nameof(SelectedReader));
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
        #endregion
        public async Task LoadAllReadersAsync()
        {
            if (AllReaders != null)
            {
                AllReaders.CollectionChanged -= OnCollectionChanged;
            }
            AllReaders.Clear();
            var readers = await _readerService.GetAllReadersAsync();
            if (readers != null)
            {
                lock (AllReaders)
                {
                    foreach (var reader in readers)
                    {
                        AllReaders.Add(reader);
                    }
                }

            }
            AllReaders.CollectionChanged += OnCollectionChanged;
            OnPropertyChanged(nameof(AllReaders));
        }
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(AllReaders));
        }
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public AddTicketPageViewModel(int bookId)
        {
            BookId = bookId;
            _readers = new ObservableCollection<Reader>();
            _reader = new Reader();
            _readerService = new ReaderService();
            _productService = new ProductService();
            SelectindReaderCommand = new Command(GiveBookToReaderAsync);
            Task.Run(() => LoadAllReadersAsync());
        }
        private async void GiveBookToReaderAsync()
        {
            if(SelectedReader != null)
            {
               await _productService.GiveBookToReaderAsync(SelectedReader.readerId, BookId);
            }
        }
    }
}
