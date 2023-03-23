using Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts
{
    internal class CandidatesContext : DbContext
    {
        public CandidatesContext(DbContextOptions options) : base(options)
        {
        }

        protected CandidatesContext()
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; }    
    }
}
