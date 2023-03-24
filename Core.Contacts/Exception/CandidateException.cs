using System.Runtime.Serialization;

namespace Core.Contacts.Exception
{
    [Serializable]
    public class CandidateException : IOException
    {
        public CandidateException()
        {
        }

        public CandidateException(string? message) : base(message)
        {
        }
    }
}