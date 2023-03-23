using Core.Contacts.Application;
using Core.Contacts.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contacts.Domain.Models
{
    public class MCandidate
    {
        public MCandidate(string firstName, string lastName, string email, string phoneNumber, string zipcode)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Zipcode = zipcode;
        }

        public MCandidate(int newId, string firstName, string lastName, string email, string phoneNumber, string zipcode)
        {
            Id = newId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Zipcode = zipcode;
        }

        public string FirstName { get; }

        public void Validate()
        {
            
            if (FirstName.Length < 2)
                throw new CandidateException($"Invalid Fist name: {FirstName}");
            if (LastName.Length < 2)
                throw new CandidateException($"Invalid Last name: {LastName}");
            if (PhoneNumber.Length < 7)
                throw new CandidateException($"Invalid phone number: {PhoneNumber}");
            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
            }
            catch (FormatException ex)
            {
                
                throw new CandidateException($"Invalid email address {Email}.\n{ex.Message}");
            }
            

        }

        public string LastName { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public string Zipcode { get; }
        public int Id { get; }
    }
}
