using System.Runtime.Serialization;

namespace System.Data
{
    [Serializable]
    internal class OptimisticConcurrencyException : Exception
    {
        public OptimisticConcurrencyException()
        {
        }

        public OptimisticConcurrencyException(string message) : base(message)
        {
        }

        public OptimisticConcurrencyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OptimisticConcurrencyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}