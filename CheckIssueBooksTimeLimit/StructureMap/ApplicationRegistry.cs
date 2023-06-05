using CheckIssuedBooksTimeLimit.DBconnect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using StructureMap;

namespace CheckIssuedBooksTimeLimit.StructureMap
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            Scan(scanner =>
            {
            scanner.TheCallingAssembly();
            scanner.AssembliesAndExecutablesFromApplicationBaseDirectory
               (assembly => assembly.GetName().Name.StartsWith("CheckIssueBooksTimeLimit."));
            scanner.AssemblyContainingType(typeof(Program));
            scanner.WithDefaultConventions();

            
            });

            var configurationBuilder = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configurationBuilder.Build();
            var connectionString = configuration.GetConnectionString("DBConnectionString");

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<LibraryServiceContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);


            string path = configuration["AppLogPath"];

            var logger = new LoggerConfiguration()
                  .ReadFrom.Configuration(configuration)
                    .WriteTo.File(path+@"\Logs\log-{Date}.txt")
                  .CreateLogger();

            Log.Logger = logger;


            For<ILogger>().Use(logger);
            For<IConfiguration>().Use(configuration).Singleton();

        }
    }
}
