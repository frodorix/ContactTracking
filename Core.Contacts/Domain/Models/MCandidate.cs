using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contacts.Domain.Models
{
    internal class MCandidate
    {
        public MCandidate(string firstName, string lastName, string email, string phoneNumber, string zipcode)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Zipcode = zipcode;
        }

        public string FirstName { get; }

        public bool IsValid()
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
                return FirstName.Length > 1
                && LastName.Length > 1
                && PhoneNumber.Length > 1
                && addr.Address == Email
                ;
            }
            catch
            {
                return false;
            }
            
        }

        public string LastName { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public string Zipcode { get; }
    }
}
