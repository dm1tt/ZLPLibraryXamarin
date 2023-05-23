using System.Text.Json.Serialization;

namespace ZLPLibrary.Model
{
    public class ShortBook
    {
        public int bookId { get; set; }
        [JsonIgnore]
        public string ProductImage { get; set; }
        public string bookName { get; set; }
        public bool inStock { get; set; }
        public string yearOfPublishing { get; set; }
        public string author { get; set; }
    }
}
