using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonThreadSafe
{
    class Singleton
    {
        private static Singleton _instance;
        public static int InstanceCounter=0;
        private Singleton()
        {
            Console.WriteLine("Instance created");
            InstanceCounter++;
        }

        public static Singleton GetInstance()
        {
                if (null == _instance)
                {
                    _instance = new Singleton();
                }

                return _instance;
        }
    }
}
