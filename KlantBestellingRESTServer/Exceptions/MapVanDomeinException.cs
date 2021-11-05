using System;
using System.Runtime.Serialization;

namespace KlantBestellingRESTServer.Exceptions
{
    public class MapVanDomeinException : Exception
    {
        public MapVanDomeinException()
        {
        }

        public MapVanDomeinException(string message) : base(message)
        {
        }

        public MapVanDomeinException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MapVanDomeinException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
