using Core.Contacts.Domain.Models;
using Core.Contacts.Interfaces;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    internal class CandidateRepository : ICandidateRepository
    {
        protected readonly CandidatesContext _dbContext;

        public CandidateRepository(CandidatesContext contex)
        {
            _dbContext = contex;
        }
      

        public async Task<int> CreateAsync(string firstName, string lastName, string email, string phoneNumber, string zipcode)
        {
            var candidate = new Candidate(firstName,lastName, email, phoneNumber, zipcode);

            this._dbContext.Add(candidate);
            await this._dbContext.SaveChangesAsync();

            return candidate.Id;
        }

        public async Task<MCandidate?> FindAsync(int id)
        {
            var candidate = await this._dbContext.Candidates
                .Where(x => x.Id == id)
                .Select(c => new MCandidate(c.Id,c.FirstName, c.LastName, c.Email, c.PhoneNumber, c.Zipcode))
                .FirstOrDefaultAsync();
            return candidate;
        }

        public async Task<IEnumerable<MCandidate>> FindCandidateAsync(string firstName, string lastName, string email, string phone, string zipcode)
        {
            var candidates = await this._dbContext.Candidates
                .Where(x => 
                    (firstName == null || x.FirstName.ToLower().Contains(firstName.ToLower()))
                   && (lastName == null || x.LastName.ToLower().Contains(lastName.ToLower()))
                   && (email == null || x.Email.ToLower().Contains(email.ToLower()))
                   && (phone == null || x.PhoneNumber.ToLower().Contains(phone.ToLower()))
                   && (zipcode == null || x.Zipcode.ToLower().Contains(zipcode.ToLower()))
               )
                .Select(c=> new MCandidate(c.Id,c.FirstName,c.LastName,c.Email, c.PhoneNumber, c.Zipcode))
                .ToListAsync(); ;
            return candidates;
        }

        public async Task<int> RemoveAsync(int id)
        {
            var candidate  = await _dbContext.Candidates.FindAsync(id);
            if (candidate == null)
                return -1;
             _dbContext.Remove(candidate);
            var couunt = await _dbContext.SaveChangesAsync();
            return couunt;
        }

        public async Task<int> UpdateAsync(MCandidate candidate)
        {
            var entidad = new Candidate() { Id = candidate.Id , FirstName=candidate.FirstName, LastName=candidate.LastName, Email=candidate.Email, PhoneNumber=candidate.PhoneNumber,Zipcode=candidate.Zipcode};
            _dbContext.Attach(entidad);
            _dbContext.Entry(entidad).State = EntityState.Modified;
            int modified = await _dbContext.SaveChangesAsync();
            return modified;
        }
    }
}
