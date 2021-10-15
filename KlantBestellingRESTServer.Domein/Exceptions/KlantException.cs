using System;
using System.Runtime.Serialization;

namespace KlantBestellingRESTServer.Domein.Exceptions
{
    [Serializable]
    public class KlantException : Exception
    {
        public KlantException()
        {
        }

        public KlantException(string message) : base(message)
        {
        }

        public KlantException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected KlantException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
