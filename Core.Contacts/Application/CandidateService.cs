using Core.Contacts.Application.Interfaces;
using Core.Contacts.Domain.Models;
using Core.Contacts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contacts.Application
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository candidateRepository;
        internal CandidateService(ICandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }
        public async Task<int> CreateCandidate(string firstName, string lastName, string email, string phoneNumber, string zipcode)
        {
            
            var candidate = new MCandidate(firstName, lastName,email,phoneNumber,zipcode);
            if (!candidate.IsValid())
                throw new CandidateException("Invalid parameters");
            int newId = await candidateRepository.Create(candidate);
            
            return newId;
        }
    }
}
