using System;
using System.Collections.Generic;
using System.Text;

namespace ZLPLibrary.Model
{
    public class ReaderTicketUsers
    {
        public int id {  get; set; }
        public Reader Reader { get; set; }
        public string receivingDate { get; set; }
        public string returnDate { get; set; }
        public int readerId { get; set; }

    }
}
