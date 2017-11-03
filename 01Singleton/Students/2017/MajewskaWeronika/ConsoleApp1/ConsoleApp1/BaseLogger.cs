using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonInheritance
{
    public abstract class BaseLogger<DerivedClass>
    {
        protected ConsoleColor logColor;
        private static DerivedClass _instance;

        public static DerivedClass GetInstance()
        {
            if (_instance == null)
            {
                _instance = (DerivedClass)Activator.CreateInstance(typeof(DerivedClass), true);
                Console.ForegroundColor = ConsoleColor.White;
            }
            return _instance;
        }

    }
}
