using Microsoft.Extensions.DependencyInjection;
using Serilog;
using CheckIssuedBooksTimeLimit.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StructureMap;
using CheckIssuedBooksTimeLimit.StructureMap;
using Serilog.Core;
using CheckIsssueBooksTimeLimit.Services.Interface;

namespace CheckIssuedBooksTimeLimit
{
    class Program
    {
        static void Main(string[] args)
        {

            // add the framework services
            var services = new ServiceCollection()
                .AddLogging();


            var container = new Container();
            container.Configure(config =>
            {
                // Register services with StructureMap
                config.AddRegistry(new ApplicationRegistry());

                // Populate the container using the service collection
                config.Populate(services);
            });

            var serviceProvider = container.GetInstance<IServiceProvider>();

            //do the actual work here
            var bar = serviceProvider.GetService<IFooService>();
            bar.DoSomething();

            //logger.LogDebug("All done!");
        }
    }
}


