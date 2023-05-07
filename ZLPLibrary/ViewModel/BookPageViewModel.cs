using System.ComponentModel;
using ZLPLibrary.Model;
using ZLPLibrary.Service;

namespace ZLPLibrary.ViewModel
{
    public class BookPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly ProductService _productService;
        public FullBook FullBook { get; set; }
        public int BookId { get; set; }
        public BookPageViewModel(int bookId)
        {
            _productService = new ProductService();
            BookId = bookId;
            LoadFullBookAsync(bookId);
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        private async void LoadFullBookAsync(int bookId)
        {
            FullBook = await _productService.GetFullBookAsync(bookId);
        }
    }
}
