using Core.Contacts.Application;
using Core.Contacts.Application.Interfaces;
using Core.Contacts.Domain.Models;
using Core.Contacts.Interfaces;

using Moq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace TestsProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// Provide functionality to do the following: 
        /// 1) A way to enter Candidate information into the system.Candidate information should be validated.
        /// Candidate information includes
        ///         a.First Name
        ///         b. Last Name
        ///         c.Email Address
        ///         d.Phone Number
        ///         e.Residential Zip Code
        /// </summary>
        [Test]
        public async Task Test_A_01_EnterCantidateInformation()
        {
            string firstName = Faker.Name.First();
            string lastName = Faker.Name.Last();
            string email = $"{Faker.Name.First()}.{Faker.Name.Last()}@{ToAlphanumeric(Faker.Company.Name())}.com";
            string phoneNumber = Faker.Phone.Number();
            string zipcode = Faker.Address.ZipCode();


            Mock<ICandidateRepository> candidateRepository = new Mock<ICandidateRepository>();
            candidateRepository
                .Setup(x => x.CreateAsync(firstName,lastName,email,phoneNumber,zipcode))
                .ReturnsAsync(1);
            ICandidateService contactsService = new CandidateService(candidateRepository.Object);

            int newId = await contactsService.CreateCandidate(firstName,lastName,email,phoneNumber,zipcode);

            Assert.That(1, Is.EqualTo(newId));

        }

        private string ToAlphanumeric(string str) {
            Regex rgx = new Regex("[^a-zA-Z0-9]");
            str = rgx.Replace(str, "");
            return str;
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
        [Test]
        public async Task Test_B_01_SearchCandidates()
        {
            Mock<ICandidateRepository> candidateRepository = new Mock<ICandidateRepository>();
            //candidateRepository
            //    .Setup(x => x.Create(candidate))
            //    .ReturnsAsync(1);
            ICandidateRepository repository= new Infrastructure.Persistence.NoStorage.Repositories.CandidateRepository();
            ICandidateService contactsService = new CandidateService(repository);
            for (int i = 0; i < 1000; i++)
            {
                string firstName = Faker.Name.First();
                string lastName = Faker.Name.Last();
                string email = $"{Faker.Name.First()}.{Faker.Name.Last()}@{ToAlphanumeric(Faker.Company.Name())}.com";
                string phoneNumber = Faker.Phone.Number().Split(" ")[0];
                string zipcode = Faker.Address.ZipCode();
                
                await contactsService.CreateCandidate(firstName, lastName, email, phoneNumber, zipcode);

            }
            await contactsService.CreateCandidate("Edwin","Rojas", "edwin.frederick@gmail.com", "59170000002", "0591");
            await contactsService.CreateCandidate("Oscar Gio", "Rojas", "oscar.rojas@gmail.com", "59160000001", "0591");

            Console.WriteLine("\nFind Edwin\n");
            var list = await contactsService.FindCandidate("edwin", "", "", null, "");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Id}: {item.FirstName} {item.LastName} {item.Email} {item.PhoneNumber} {item.Zipcode}");
            }

            Assert.That(list.Count(), Is.GreaterThan(0));

            Console.WriteLine("\nFind at least Edwin and Oscar Rojas\n");    
             list = await contactsService.FindCandidate("i", "Rojas", "", null, "");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Id}: {item.FirstName} {item.LastName} {item.Email} {item.PhoneNumber} {item.Zipcode}");
            }
            Assert.That(list.Count(), Is.GreaterThan(1));

        }

        /// <summary>
        /// 3) Pre-population of Candidates 
        ///         a.To help both YOU and US verify your work and verify that search works, pre-populate
        ///         some candidates with various properties.This can be done within the code / in memory for
        /// this exercise, in order to save time.
        /// </summary>
        [Test]
        public void Test_C_01_Pre_populationofCandidates()
        {
            //Done with Faker.Net in Infrastructure Extensions
            Assert.Pass();
        }
    }
}