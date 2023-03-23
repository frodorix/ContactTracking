using Core.Contacts.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contacts.Application.Interfaces
{
    public interface ICandidateService
    {
        Task<int> CreateCandidate(string fistName, string lastName, string email, string phoneNumber, string zipcode);
        Task<IEnumerable<MCandidate>> FindCandidate(string fistName, string lastName, string email, string phone, string zipcode);
    }
}
