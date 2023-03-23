using System.Runtime.Serialization;

namespace Core.Contacts.Exception
{
    [Serializable]
    internal class CandidateException : IOException
    {
        public CandidateException()
        {
        }

        public CandidateException(string? message) : base(message)
        {
        }
    }
}