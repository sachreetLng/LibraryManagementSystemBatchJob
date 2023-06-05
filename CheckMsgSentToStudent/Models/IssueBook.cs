using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMsgSentToStudent.Models
{
    public class IssueBook
    {
        public virtual int Id { get; set; }
        public virtual int StudentId { get; set; }
        public virtual string StudentNumber { get; set; }
        public virtual string StudentDepartment { get; set; }
        public virtual string StudentSemester { get; set; }
        public virtual long StudentContact { get; set; }
        public virtual string StudentEmail { get; set; }
        public virtual string BookName { get; set; }
        public virtual DateTime IssueDate { get; set; }
        public virtual DateTime? ReturnDate { get; set; }
    }
}
