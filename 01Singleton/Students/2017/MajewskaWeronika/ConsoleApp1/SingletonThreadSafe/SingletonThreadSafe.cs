using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonThreadSafe
{
    class SingletonThreadSafe
    {
        private static SingletonThreadSafe _instance = null;
        private static object syncObject = new object();
        private int _instanceCounter = 0;

        private SingletonThreadSafe()
        {
            _instanceCounter++;
            Console.WriteLine("Instance number = {0}", _instanceCounter);
        }

        public static SingletonThreadSafe GetInstance()
        {
            if (_instance == null)
            {
                lock (syncObject)
                {
                    _instance = new SingletonThreadSafe();

                }
            }
            return _instance;
        }
    }
}
