using System;
using System.Runtime.Serialization;

namespace FilmsManagement.Infrastructure.Core.Exceptions
{
    [Serializable]
    public class FilmsSearchRequestException : Exception
    {
        public FilmsSearchRequestException()
        {
        }

        public FilmsSearchRequestException(string message) : base(message)
        {
        }

        public FilmsSearchRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FilmsSearchRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
