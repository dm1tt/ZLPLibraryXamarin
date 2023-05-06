using System;


namespace ZLPLibrary.Model
{
    public class ShortBook
    {
        public int ProductId { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public bool InStock { get; set; }
        public DateTime YearOfPublishing { get; set; }
        public string Author { get; set; }
    }
}
