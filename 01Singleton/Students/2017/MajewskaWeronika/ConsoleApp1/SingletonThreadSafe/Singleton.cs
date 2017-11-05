using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonThreadSafe
{
    class Singleton
    {
        private static Singleton _instance = null;
        private int _instanceCounter = 0;

        private Singleton()
        {
            _instanceCounter++;
            Console.WriteLine("Instance number = {0}", _instanceCounter);
        }

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }
}
