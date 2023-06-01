using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIssuedBooksTimeLimit.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string BookPublication { get; set; }
        public string BookDate { get; set; }
        public long BookPrice { get; set; }
        public long BookQuantity { get; set; }
    }
}
