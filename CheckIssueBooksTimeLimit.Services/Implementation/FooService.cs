using CheckIsssueBooksTimeLimit.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace CheckIsssueBooksTimeLimit.Services.Implementation
{
    public class FooService : IFooService
    {
        private readonly ILogger _logger;

        public FooService(ILogger logger)
        {
            this._logger = logger;
            _logger.Information("sddfghdg");
        }
        public void DoSomething()
        {
            Console.WriteLine("Hello DoSomething metho callled from FooService");
        }
    }
}
