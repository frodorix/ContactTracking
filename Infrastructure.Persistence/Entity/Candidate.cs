using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Entity
{
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

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Zipcode { get; set; }
        public int Id { get; set; }
    }
}
