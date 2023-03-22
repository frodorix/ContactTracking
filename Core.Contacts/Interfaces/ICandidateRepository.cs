using Core.Contacts.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contacts.Interfaces
{
    internal interface ICandidateRepository
    {
      Task<int>   Create(MCandidate candidate)
    }
}
