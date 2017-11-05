using System;
using System.Runtime.Serialization;

namespace SingletonSerialization
{
    [Serializable]
    internal class SingletonSerializationHelper : IObjectReference
    {
        public object GetRealObject(StreamingContext context)
        {
           return Singleton.GetInstance;
        }
    }
}