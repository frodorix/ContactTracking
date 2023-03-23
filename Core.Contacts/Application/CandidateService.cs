using Core.Contacts.Application.Interfaces;
using Core.Contacts.Domain.Models;
using Core.Contacts.Exception;
using Core.Contacts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contacts.Application
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository candidateRepository;
        public CandidateService(ICandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }
        /// <summary>
        /// Creates a new candidate
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        /// <exception cref="CandidateException"></exception>
        public async Task<int> CreateCandidate(string firstName, string lastName, string email, string phoneNumber, string zipcode)
        {

            var candidate = new MCandidate(firstName, lastName, email, phoneNumber, zipcode);
            candidate.Validate();
            int newId = await candidateRepository.Create(firstName, lastName, email, phoneNumber, zipcode);
            
            return newId;
        }

        /// <summary>
        /// 2) Search Candidates. This should provide the ability to search the candidates entered in Step 1 
        /// and present the results to the end user in a grid or some other manner - presentation is up to
        /// you.Search criteria shouldsupport: 
        ///     a.First Name
        ///     b.Last Name
        ///     c.Email Address
        ///     d.Phone Number
        ///     e.Residential Zip Code
        /// </summary>
        /// <param name="fistName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        public async Task<IEnumerable<MCandidate>> FindCandidate(string fistName, string lastName, string email, string phone, string zipcode)
        {

            IEnumerable<MCandidate> candidates = await this.candidateRepository.FindCandidate(fistName, lastName, email, phone, zipcode);
                return candidates;
        }

        
    }
}
