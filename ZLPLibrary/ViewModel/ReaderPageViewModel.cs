using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ZLPLibrary.Model;
using ZLPLibrary.Service;

namespace ZLPLibrary.ViewModel
{
    public class ReaderPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly ReaderService _readerService;
        private Reader _reader;
        public Reader Reader { get; set; }
        #region
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
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
        public ReaderPageViewModel(Reader reader)
        {
            _readerService = new ReaderService();
            _reader = new Reader();
            Reader = reader;
        }
    }
}
