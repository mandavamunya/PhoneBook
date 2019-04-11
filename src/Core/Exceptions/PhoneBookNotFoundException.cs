using System;
using System.Runtime.Serialization;

namespace Core.Exceptions
{
    public class PhoneBookNotFoundException: Exception
    {
        public PhoneBookNotFoundException(int phoneBookId)
             : base($"No phonebook found with id {phoneBookId}")
        {
        }

        protected PhoneBookNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public PhoneBookNotFoundException(string message)
            : base(message)
        {
        }

        public PhoneBookNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
