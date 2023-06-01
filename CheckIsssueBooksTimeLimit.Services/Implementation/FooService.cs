using CheckIsssueBooksTimeLimit.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIsssueBooksTimeLimit.Services.Implementation
{
    public class FooService : IFooService
    {
        public void DoSomething()
        {
            Console.WriteLine("Hello DoSomething metho callled from FooService");
        }
    }
}
