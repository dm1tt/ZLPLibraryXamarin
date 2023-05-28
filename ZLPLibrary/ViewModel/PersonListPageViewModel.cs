using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading.Tasks;
using ZLPLibrary.Model;
using ZLPLibrary.Service;

namespace ZLPLibrary.ViewModel
{
    public class PersonListPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Reader _reader;
        private ObservableCollection<Reader> _readers;
        private ReaderService _readerService;

        public PersonListPageViewModel()
        {
            _readers = new ObservableCollection<Reader>();
            _reader = new Reader();
            _readerService = new ReaderService();
            LoadAllReadersAsync();
        }
        #region
        public ObservableCollection<Reader> AllReaders
        {
            get { return _readers; }
            set
            {
                if (_readers != value)
                {
                    _readers = value;
                    OnPropertyChanged(nameof(AllReaders));
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
        #endregion
        private async Task LoadAllReadersAsync()
        {
            AllReaders.CollectionChanged -= OnCollectionChanged;
            AllReaders.Clear();
            var readers = await _readerService.GetAllReadersAsync();
            if (readers != null)
            {
                foreach (var reader in readers)
                {
                    AllReaders.Add(reader);
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
    }
}
