using Core.Contacts.Domain.Models;
using Core.Contacts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.NoStorage.Repositories
{
    public class CandidateRepository: ICandidateRepository
    {
        private List<MCandidate> _candidatesDB;
        private int lastId = 1;
        public CandidateRepository() {
            _candidatesDB = new List<MCandidate>();
        }
        public async Task<int> CreateAsync(string firstName, string lastName, string email, string phoneNumber, string zipcode)
        {
            int newId = Interlocked.Increment(ref lastId);
            _candidatesDB.Add(new MCandidate(newId ,firstName, lastName, email, phoneNumber, zipcode));

            return  newId;
        }

        public async Task<MCandidate?> FindAsync(int id)
        {
            return this._candidatesDB.Where(X => X.Id == id).FirstOrDefault();
        }

        public async Task<IEnumerable<MCandidate>> FindCandidateAsync(string firstName, string lastName, string email, string phone, string zipcode)
        {
            var candidates = _candidatesDB.Where(
                x => (firstName == null || x.FirstName.ToLower().Contains(firstName.ToLower()))
                    && (lastName == null || x.LastName.ToLower().Contains(lastName.ToLower()))
                    && (email == null || x.Email.ToLower().Contains(email.ToLower()))
                    && (phone == null || x.PhoneNumber.ToLower().Contains(phone.ToLower()))
                    && (zipcode == null || x.Zipcode.ToLower().Contains(zipcode.ToLower()))
                ).ToList(); ;
            return candidates;
        }

        public async Task<int> RemoveAsync(int id)
        {
          int count =  this._candidatesDB.RemoveAll(x => x.Id == id);
            return count;
        }

        public async Task<int> UpdateAsync(MCandidate candidate)
        {
            await this.RemoveAsync(candidate.Id);
             _candidatesDB.Add(candidate);
            return 1;
        }
    }
}
