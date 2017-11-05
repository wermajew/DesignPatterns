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
        public static int InstanceCounter { get; private set; }

        private Singleton()
        {
            InstanceCounter++;
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
