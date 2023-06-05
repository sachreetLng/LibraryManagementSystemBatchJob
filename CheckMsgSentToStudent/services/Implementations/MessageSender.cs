using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckMsgSentToStudent.Models;
using CheckMsgSentToStudent.services.Interfaces;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
 
namespace CheckMsgSentToStudent.services.Implementations
{
    public class MessageSender : IMessageSender
    {
        public  List<Student> GetStudents(ISession session)
        {
            var studentIds = session.Query<BookReminder>()
                .Where(x => x.IsMessageSent == false)
                .Select(x => x.StudentId)
                .ToList();

            var students = session.Query<Student>()
                .Where(s => studentIds.Contains(s.StudentId))
                .ToList();

            return students;
        }

        public  void UpdateIsMsgSent(ISession session, int studentId)
        {
            var reminders = session.Query<BookReminder>().Where(x => x.StudentId == studentId).ToList();

            foreach (var reminder in reminders)
            {
                reminder.IsMessageSent = true;
                session.SaveOrUpdate(reminder);
            }
        }

    }
}
