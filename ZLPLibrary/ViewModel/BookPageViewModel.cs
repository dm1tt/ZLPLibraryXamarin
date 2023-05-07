using System.Collections.Generic;
using System.ComponentModel;
using ZLPLibrary.Model;

namespace ZLPLibrary.ViewModel
{
    public class BookPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int BookId { get; set; }
        public BookPageViewModel(int bookId)
        {
            BookId = bookId;
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
