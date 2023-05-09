using System;
using System.Collections.Generic;
using System.Text;

namespace ZLPLibrary.Model
{
    public class FullBookResponse : FullBook
    {
        public FullBook book { get; set; }
        public List<ReaderTicketUsers> readerTicketUsers { get; set; }
    }
}
