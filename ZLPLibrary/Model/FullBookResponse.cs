using System.Collections.Generic;

namespace ZLPLibrary.Model
{
    public class FullBookResponse : FullBook
    {
        public FullBook book { get; set; }
        public List<ReaderTicketUsers> readerTicketUsers { get; set; }
    }
}
