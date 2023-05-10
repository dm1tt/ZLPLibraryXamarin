using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZLPLibrary.Model;

namespace ZLPLibrary.ViewModel
{
    public class AddBookPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand AddNewBookCommand { protected get; set; }
        public AddBookPageViewModel(FullBook fullBook)
        {
            AddNewBookCommand = new Command();//разберись димон дальше
        }
        private void AddNewBook(FullBook fullBook)
        {

        }
    }
}
