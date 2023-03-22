using System.Runtime.Serialization;

namespace Core.Contacts.Application
{
    [Serializable]
    internal class CandidateException : Exception
    {
        public CandidateException()
        {
        }

        public CandidateException(string? message) : base(message)
        {
        }

        public CandidateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CandidateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}