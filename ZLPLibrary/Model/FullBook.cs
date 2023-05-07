using System;
using System.Collections.Generic;
using System.Text;

namespace ZLPLibrary.Model
{
    public class FullBook
    {
        public int bookId { get; set; }
        public string bookName { get; set; }
        public string authors { get; set; }
        public int numberOfPages { get; set; }
        public string publishingHouse { get; set; }
        public string yearOfPublication { get; set; }
        public string inStock { get; set; }
    }
}
