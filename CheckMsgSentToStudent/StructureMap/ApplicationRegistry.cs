using CheckMsgSentToStudent;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using Serilog;
using StructureMap;
using System.Configuration;

namespace CheckMsgSentToStudent.StructureMap
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                scanner.AssembliesAndExecutablesFromApplicationBaseDirectory(assembly => assembly.GetName().Name.StartsWith("CheckIssueBooksTimeLimit."));
                scanner.AssemblyContainingType(typeof(Program));
                scanner.WithDefaultConventions();
            });

            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configurationBuilder.Build();


            string path = configuration["AppLogPath"];

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.File(path + @"\Logs\log-{Date}.txt")
                .CreateLogger();

            Log.Logger = logger;

        }

    }
}
