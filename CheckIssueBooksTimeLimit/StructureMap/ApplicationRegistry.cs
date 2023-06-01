using Lamar;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIssuedBooksTimeLimit.StructureMap
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                scanner.WithDefaultConventions();
                scanner.AssemblyContainingType(typeof(Program));
                scanner.AssembliesAndExecutablesFromApplicationBaseDirectory(assembly =>
                assembly.GetName().Name.StartsWith("CheckIssuedBooksTimeLimit."));
            });



        }
    }
}
