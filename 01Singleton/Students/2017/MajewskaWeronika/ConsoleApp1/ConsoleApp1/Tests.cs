using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var greenSingletonFirst = GreenLogger.GetInstance();
            var greenSingletonSecond = GreenLogger.GetInstance();

            Console.WriteLine("Are green singletons equal: {0}", greenSingletonSecond.Equals(greenSingletonFirst) + "\n\n");

            var redSingletonFirst = RedLogger.GetInstance();
            var redSingletonSecond = RedLogger.GetInstance();

            Console.WriteLine("Are red singletons equal: {0}", redSingletonFirst.Equals(redSingletonSecond) + "\n\n");

            Console.WriteLine("Are red and green singletons equal: {0}", greenSingletonFirst.Equals(redSingletonSecond) + "\n\n");
        }

    }
}
