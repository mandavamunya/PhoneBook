using System;
using System.Runtime.Serialization;

namespace Core.Exceptions
{
    public class EntryNotFoundException: Exception
    {
        public EntryNotFoundException(int entryId)
             : base($"No entry found with id {entryId}")
        {
        }

        protected EntryNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public EntryNotFoundException(string message)
            : base(message)
        {
        }

        public EntryNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
