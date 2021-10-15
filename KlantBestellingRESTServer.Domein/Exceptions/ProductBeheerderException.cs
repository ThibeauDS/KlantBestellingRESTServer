using System;
using System.Runtime.Serialization;

namespace KlantBestellingRESTServer.Domein.Exceptions
{
    [Serializable]
    public class ProductBeheerderException : Exception
    {
        public ProductBeheerderException()
        {
        }

        public ProductBeheerderException(string message) : base(message)
        {
        }

        public ProductBeheerderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProductBeheerderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
