using System;
using System.Collections.Generic;
using System.ComponentModel;
using ZLPLibrary.Model;

namespace ZLPLibrary.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ShortBook _shortbook;
        public event PropertyChangedEventHandler PropertyChanged;
        public List<ShortBook> Books { get; set; }
        public MainPageViewModel()
        {
            _shortbook = new ShortBook();
            Books = new List<ShortBook>
            {
                new ShortBook
                {
                    ProductId = 1,
                    ProductImage = "Povelitel_muh.jpg",
                    ProductName = "Повелитель мух",
                    InStock = true,
                    YearOfPublishing = DateTime.Now.Date
                },
                new ShortBook
                {
                    ProductId = 2,
                    ProductImage = "Voyna_i_mir.jpg",
                    ProductName = "Война и мир",
                    InStock = true,
                    YearOfPublishing = DateTime.Today.Date
                },
                new ShortBook
                {
                    ProductId = 3,
                    ProductImage = "Beznadega.jpg",
                    ProductName = "Безнадёга",
                    InStock = true,
                    YearOfPublishing = DateTime.Now.Date
                },
                new ShortBook
                {
                    ProductId = 4,
                    ProductImage = "Kladbishe.jpg",
                    ProductName = "Кладбище домашних животных",
                    InStock = true,
                    YearOfPublishing = DateTime.Now.Date
                },
                new ShortBook
                {
                    ProductId = 5,
                    ProductImage = "SAO.jpg",
                    ProductName = "Мастера меча онлайн",
                    InStock = false,
                    YearOfPublishing = DateTime.Now.Date
                },
                new ShortBook
                {
                    ProductId = 6,
                    ProductImage = "Berserk.jpg",
                    ProductName = "Берсерк",
                    InStock = true,
                    YearOfPublishing = DateTime.Now.Date
                },
                new ShortBook
                {
                    ProductId = 7,
                    ProductImage = "Minecraft.jpg",
                    ProductName = "Майнкрафт рецепты",
                    InStock = true,
                    YearOfPublishing = DateTime.Now.Date
                },
                new ShortBook
                {
                    ProductId = 8,
                    ProductImage = "Boobs.jpg",
                    ProductName = "Письки сиськи два ствола",
                    InStock = false,
                    YearOfPublishing = DateTime.Now.Date
                },
                new ShortBook
                {
                    ProductId = 9,
                    ProductImage = "Gena.jpg",
                    ProductName = "Гена Штроппин и тайная комната",
                    InStock = true,
                    YearOfPublishing = DateTime.Now.Date
                },
                 new ShortBook
                {
                   ProductId = 10,
                   ProductImage = "Uspeh.jpg",
                   ProductName = "Путь к успеху",
                   InStock = true,
                   YearOfPublishing = DateTime.Now.Date
                }
            };

        }
        public int ProductId
        {
            get { return _shortbook.ProductId; }
            set
            {
                if (_shortbook.ProductId != value)
                {
                    _shortbook.ProductId = value;
                    OnPropertyChanged("ProductImage");
                }
            }
        }
        public string ProductImage
        {
            get { return _shortbook.ProductImage; }
            set
            {
                if (_shortbook.ProductImage != value)
                {
                    _shortbook.ProductImage = value;
                    OnPropertyChanged("ProductImage");
                }
            }
        }
        public string ProductName
        {
            get { return _shortbook.ProductName; }
            set
            {
                if (_shortbook.ProductName != value)
                {
                    _shortbook.ProductName = value;
                    OnPropertyChanged("ProductName");
                }
            }
        }
        public bool InStock
        {
            get { return _shortbook.InStock; }
            set
            {
                if (_shortbook.InStock != value)
                {
                    _shortbook.InStock = value;
                    OnPropertyChanged("InStock");
                }
            }
        }
        public string Author
        {
            get { return _shortbook.Author; }
            set
            {
                if (_shortbook.Author != value)
                {
                    _shortbook.Author = value;
                    OnPropertyChanged("Author");
                }
            }
        }
        public DateTime YearOfPublishing
        {
            get { return _shortbook.YearOfPublishing; }
            set
            {
                if (_shortbook.YearOfPublishing != value)
                {
                    _shortbook.YearOfPublishing = value;
                    OnPropertyChanged("YearOfPublishing");
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}