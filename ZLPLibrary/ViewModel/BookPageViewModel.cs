using System.Collections.Generic;
using System.ComponentModel;
using ZLPLibrary.Model;

namespace ZLPLibrary.ViewModel
{
    public class BookPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ShortBook shortBook { get; set; }
        public BookPageViewModel(ShortBook book)
        {
            shortBook = book;
        }
    }
}
