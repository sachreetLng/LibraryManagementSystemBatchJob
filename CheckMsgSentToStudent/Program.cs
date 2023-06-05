using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Reflection;
using CheckMsgSentToStudent.Models;
using NHibernate;
using CheckMsgSentToStudent.StructureMap;
using CheckMsgSentToStudent.services.Interfaces;

namespace CheckMsgSentToStudent
{
    class Program
    {
        private static ISessionFactory sessionFactory;

        static void Main(string[] args)
        {
            string connStr = "Data Source = DESKTOP-PHC5QCQ\\SQLEXPRESS; Initial Catalog = LMS; Trusted_Connection = SSPI; Encrypt = false; Integrated Security = True;";
            var config = new Configuration();
            config.DataBaseIntegration(d =>
            {
                d.ConnectionString = connStr;
                d.Dialect<MsSql2008Dialect>();
                d.Driver<SqlClientDriver>();
            });
            config.AddAssembly(Assembly.GetExecutingAssembly());
            sessionFactory = config.BuildSessionFactory();

            var services = new ServiceCollection()
                .AddLogging();

            var container = new Container();
            container.Configure(config =>
            {
                config.AddRegistry(new ApplicationRegistry());
                config.For<ISessionFactory>().Use(sessionFactory);
                config.Populate(services);
            });
            var serviceProvider = container.GetInstance<IServiceProvider>();

            var messagesendReminder = container.GetInstance<MessageSendReminder>();

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                messagesendReminder.NotifyStudents(session);
                transaction.Commit();
            }
        }
    }
}
