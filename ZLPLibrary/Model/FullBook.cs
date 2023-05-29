using System;

namespace ZLPLibrary.Model
{
    [Serializable]
    public class FullBook
    {
        public int bookId { get; set; }
        public string typeId { get; set; }
        public string bookName { get; set; }
        public string authors { get; set; }
        public int? numberOfPage { get; set; }
        public string publishingHouse { get; set; }
        public string yearOfPublication { get; set; }
        public bool inStock { get; set; }
    }
}
