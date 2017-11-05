using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SingletonSerialization
{
    [Serializable]
    public class Singleton : ISerializable
    {
        public static int counter = 0;
        public static Singleton uniqueInstance = null;
        public static object syncObject = new object();

        public static Singleton GetInstance
        {
            get
            {
                if (uniqueInstance == null)
                {
                    lock (syncObject)
                    {
                        uniqueInstance = new Singleton();
                    }
                }
                return uniqueInstance;
            }
        }


        private Singleton()
        {
            counter++;
            Console.WriteLine("Instance" + counter);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(SingletonSerializationHelper));
        }
    }
}
