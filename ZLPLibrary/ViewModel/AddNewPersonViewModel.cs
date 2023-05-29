using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZLPLibrary.Model;
using ZLPLibrary.Service;

namespace ZLPLibrary.ViewModel
{
    public class AddNewPersonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly ReaderService _readerService;
        private readonly Reader _newReader;
        public Reader NewReader { get; set; }
        public ICommand AddNewPersonCommand { get; }
        public ICommand UpdateReadersListCommand { get; }
        #region
        public string firstName
        {
            get { return _newReader.firstName; }
            set
            {
                if (_newReader.firstName != value)
                {
                    _newReader.firstName = value;
                    OnPropertyChanged(nameof(firstName));
                }
            }
        }
        public string secondName
        {
            get { return _newReader.secondName; }
            set
            {
                if (_newReader.secondName != value)
                {
                    _newReader.secondName = value;
                    OnPropertyChanged(nameof(secondName));
                }
            }
        }
        public string thirdName
        {
            get { return _newReader.thirdName; }
            set
            {
                if (_newReader.thirdName != value)
                {
                    _newReader.thirdName = value;
                    OnPropertyChanged(nameof(thirdName));
                }
            }
        }
        public string ticketNumber
        {
            get { return _newReader.ticketNumber; }
            set
            {
                if (_newReader.ticketNumber != value)
                {
                    _newReader.ticketNumber = value;
                    OnPropertyChanged(nameof(ticketNumber));
                }
            }
        }
        #endregion
        public AddNewPersonViewModel()
        {
            _readerService = new ReaderService();
            _newReader = new Reader();
            NewReader = _newReader;
            AddNewPersonCommand = new Command(AddNewPersonAsync);
            //UpdateReadersListCommand = new Command(UpdateReadersList);
        }
/*
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(App.AllReaders));
        }*/

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        private async void AddNewPersonAsync()
        {
            await _readerService.PostNewBookAsync(NewReader);
        }

/*        private async void UpdateReadersList()
        {
            App.AllReaders.CollectionChanged -= OnCollectionChanged;
            App.AllReaders.Clear();
            var readers = await _readerService.GetAllReadersAsync();
            if (readers != null)
            {
                foreach (var reader in readers)
                {
                    App.AllReaders.Add(reader);
                }
            }
            App.AllReaders.CollectionChanged += OnCollectionChanged;
            //OnPropertyChanged(nameof(App.AllReaders));
        }*/
    }
}
