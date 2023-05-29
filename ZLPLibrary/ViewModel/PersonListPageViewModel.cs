﻿using System.Collections.ObjectModel;
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
    public class PersonListPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Reader _reader;
        private ObservableCollection<Reader> _readers;
        private ReaderService _readerService;
        private ObservableCollection<Reader> _searchResults;
        #region
        public ObservableCollection<Reader> SearchResults
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
        public ObservableCollection<Reader> GetSearchResults(string queryString)
        {
            var normalizedQuery = queryString;
            return new ObservableCollection<Reader>(AllReaders.Where(n => n.secondName.Contains(normalizedQuery)));
        }
        #endregion
        public ICommand CancelngSearch => new Command<string>((string query) =>
        {
            SearchResults = GetSearchResults("");
        });
        public ICommand PerformSearch => new Command<string>((string query) =>
        {
            SearchResults = GetSearchResults(query);
        });
        public PersonListPageViewModel()
        {
            _readers = new ObservableCollection<Reader>();
            _reader = new Reader();
            _readerService = new ReaderService();
            _searchResults = AllReaders;
            Task.Run(() => LoadAllReadersAsync());
        }

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
    }
}
