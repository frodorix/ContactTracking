using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Entity
{
    [Table("Candidate")]
    internal class Candidate
    {
        public Candidate() { }
        public Candidate(string firstName, string lastName, string email, string phoneNumber, string zipcode)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Zipcode = zipcode;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string Zipcode { get; set; }
        
    }
}
