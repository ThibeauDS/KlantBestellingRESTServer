using System;
using System.Runtime.Serialization;

namespace KlantBestellingRESTServer.Exceptions
{
    public class KlantBestellingControllerException : Exception
    {
        public KlantBestellingControllerException()
        {
        }

        public KlantBestellingControllerException(string message) : base(message)
        {
        }

        public KlantBestellingControllerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected KlantBestellingControllerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
