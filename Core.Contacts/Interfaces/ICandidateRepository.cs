using Core.Contacts.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contacts.Interfaces
{
    public interface ICandidateRepository
    {
        Task<int> CreateAsync(string firstName, string lastName, string email, string phoneNumber, string zipcode);
        Task<IEnumerable<MCandidate>> FindCandidateAsync(string fistName, string lastName, string email, string phone, string zipcode);
        Task<MCandidate?> FindAsync(int id);
        Task<int> RemoveAsync(int id);
        Task<int> UpdateAsync(MCandidate candidate);
    }
}
