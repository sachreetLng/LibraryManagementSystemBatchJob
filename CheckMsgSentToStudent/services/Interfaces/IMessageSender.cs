using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckMsgSentToStudent.Models;

namespace CheckMsgSentToStudent.services.Interfaces
{
    public interface IMessageSender
    {
        public  List<Student> GetStudents(ISession session);
        public  void UpdateIsMsgSent(ISession session, int studentId);
    }
}
