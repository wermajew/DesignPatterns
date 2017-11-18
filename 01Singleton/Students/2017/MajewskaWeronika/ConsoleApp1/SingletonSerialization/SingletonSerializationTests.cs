using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SingletonSerialization
{
    class SingletonSerializationTests
    {
        static void Main(string[] args)
        {
            var singletonNotSerialized = Singleton.GetInstance;

            Stream stream = File.Open("singleton.txt", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();

            var singletonSerialized = Singleton.GetInstance;
            bformatter.Serialize(stream, singletonSerialized);
            stream.Close();

            stream = File.Open("singleton.txt", FileMode.Open);
            var singletonDeserialised = (Singleton)bformatter.Deserialize(stream);

            Console.WriteLine("Singleton before serialization is the same instance after serialization ===> " + singletonNotSerialized.Equals(singletonDeserialised));
        }
    }
}
