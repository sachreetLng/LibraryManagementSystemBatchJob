using CheckIssueBooksTimeLimit.Services.Interface;
using CheckMsgSentToStudent.services.Interfaces;
using Microsoft.Extensions.Configuration;
using NHibernate;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using CheckIssuedBooksTimeLimit.Core.Entities;

namespace CheckMsgSentToStudent
{
    public class MessageSendReminder
    {

        private readonly IMessageSender _messageSender;
        private readonly int _days;
        private readonly ISessionFactory _sessionFactory;



        public MessageSendReminder(IMessageSender messageSender, ISessionFactory sessionFactory)
        {
            this._messageSender = messageSender;
            this._sessionFactory = sessionFactory;
        }

        public void NotifyStudents(ISession session)
        {
            var students = _messageSender.GetStudents(session);

            foreach (var student in students)
            {
                bool isMsgSent = ListenForIntegrationEvents();

                if (isMsgSent)
                {
                    _messageSender.UpdateIsMsgSent(session, student.StudentId);
                }
            }
        }

        public bool ListenForIntegrationEvents()
        {
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
                var data = JObject.Parse(message);
                var type = ea.RoutingKey;
                if (type == "reminder.add")
                {

                    Log.Information("Received message: {@Message}", new
                    {
                        StudentId = data["StudentId"].Value<int>(),
                        Message = data["Message"].Value<string>()
                    });
                }
            };

            channel.BasicConsume(queue: "book.postservice", autoAck: true, consumer: consumer);
            return true;
        }
    }
}
