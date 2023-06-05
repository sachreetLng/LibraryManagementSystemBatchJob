using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMsgSentToStudent.Models
{
    public class BookReminder
    {
        public virtual int Id { get; set; }
        public virtual int StudentId { get; set; }
        public virtual int BookId { get; set; }
        public virtual int DaysExceededToReturnBook { get; set; }
        public virtual string MessageText { get; set; }
        public virtual bool IsMessageSent { get; set; } = false;
    }
}
