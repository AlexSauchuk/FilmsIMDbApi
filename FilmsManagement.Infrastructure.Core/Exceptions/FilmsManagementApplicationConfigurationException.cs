using System;
using System.Runtime.Serialization;

namespace FilmsManagement.Infrastructure.Core.Exceptions
{
    [Serializable]
    public class FilmsManagementApplicationConfigurationException : Exception
    {
        public FilmsManagementApplicationConfigurationException()
        {
        }

        public FilmsManagementApplicationConfigurationException(string message) : base(message)
        {
        }
    
        public FilmsManagementApplicationConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FilmsManagementApplicationConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
