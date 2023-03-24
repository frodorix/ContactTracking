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
        Task<int> CreateCandidate(string firstName, string lastName, string email, string phoneNumber, string zipcode);
        Task<MCandidate> FindAsync(int id);
        Task<IEnumerable<MCandidate>> FindCandidate(string firstName, string lastName, string email, string phone, string zipcode);
        Task<int> Remove(int id);
        Task<int> UpdateAsync(int id, string firstName, string lastName, string email, string phoneNumber, string zipcode);
    }
}
