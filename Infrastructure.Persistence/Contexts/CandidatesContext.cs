using Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts
{
    internal class CandidatesContext : DbContext
    {
        public CandidatesContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost, 8433;Initial Catalog=Candidates;Persist Security Info=True;User ID=sa;Password=yourStrongPassword#;TrustServerCertificate=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Candidate>()
            .HasIndex(u => u.Email)
            .IsUnique();

           
        }
    }
}
