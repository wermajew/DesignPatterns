using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonThreadSafe
{
    class SingletonThreadingSafe
    {
        private static SingletonThreadingSafe _instance = null;
        private static object syncObject = new object();
        public static int InstanceCounter { get; private set; }

        private SingletonThreadingSafe()
        {
            InstanceCounter++;
            Console.WriteLine("Instance number = {0}", InstanceCounter);
        }

        public static SingletonThreadingSafe GetInstance()
        {
            lock (syncObject)
            {
                if (_instance == null)
                {
                    _instance = new SingletonThreadingSafe();
                }
            }

            return _instance;
        }
    }
}
