using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIssuedBooksTimeLimit.Entities
{
    public class BookReminder
    {
        public int StudentId { get; set; }
        public int BookId { get; set; }
        public int DaysExceededToReturnBook { get; set; }
        public string MessageText { get; set; }
        public bool IsMessageSent { get; set; }
    }
}
