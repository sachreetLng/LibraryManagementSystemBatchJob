using Microsoft.Extensions.DependencyInjection;
using Serilog;
using CheckIssuedBooksTimeLimit.DBconnect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StructureMap;
using CheckIssuedBooksTimeLimit.StructureMap;
using Serilog.Core;
using CheckIssueBooksTimeLimit.Services.Implementation;
using CheckIssueBooksTimeLimit.Services.Interface;
using CheckIssueBooksTimeLimit;

namespace CheckIssuedBooksTimeLimit
{
    class Program
    {
        static void Main(string[] args)
        {

            var services = new ServiceCollection()
                .AddLogging();


            var container = new Container();
            container.Configure(config =>
            {
                config.AddRegistry(new ApplicationRegistry());

                config.Populate(services); 
            });

            
            var serviceProvider = container.GetInstance<IServiceProvider>();
            var bookReminderService= container.GetInstance<BookReminderService>();
            bookReminderService.CheckBooksToNotify();
            
        }
    }
}


