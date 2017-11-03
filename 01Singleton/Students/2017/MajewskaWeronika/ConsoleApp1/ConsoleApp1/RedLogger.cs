using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonInheritance
{
    public class RedLogger : BaseLogger<RedLogger>
    {
        private RedLogger()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Constructor of RedLogger has been invoked");
        }
    }
}
