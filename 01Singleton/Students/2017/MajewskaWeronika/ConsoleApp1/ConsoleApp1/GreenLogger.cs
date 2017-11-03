using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonInheritance
{
    public class GreenLogger : BaseLogger<GreenLogger>
    {
        private GreenLogger()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Constructor of GreenLogger has been invoked");
        }
    }
}
