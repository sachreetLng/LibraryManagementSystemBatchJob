using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIssuedBooksTimeLimit.Core.Entities;


namespace CheckIssueBooksTimeLimit.Services.Interface
{
    public interface IBookService
    {
        public void SendMsgToStudentForBookReminder(int studentId, int bookId, int daysExceeded, string messageText);
        List<IssueBook> GetBooksIssued();
    }
}
