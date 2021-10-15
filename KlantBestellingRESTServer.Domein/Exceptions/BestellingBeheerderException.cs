using System;
using System.Runtime.Serialization;

namespace KlantBestellingRESTServer.Domein.Exceptions
{
    [Serializable]
    public class BestellingBeheerderException : Exception
    {
        public BestellingBeheerderException()
        {
        }

        public BestellingBeheerderException(string message) : base(message)
        {
        }

        public BestellingBeheerderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BestellingBeheerderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
