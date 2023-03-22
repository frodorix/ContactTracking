using Core.Contacts.Application;
using Core.Contacts.Application.Interfaces;

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
            ICandidateService contactsService = new CandidateService();
            string firstName= Faker.Name.First(); 
            string lastName = Faker.Name.Last(); 
            string email = $"{Faker.Name.First()}.{Faker.Name.Last()}@{Faker.Company.BS()}.com"; 
            string phoneNumber= Faker.Phone.Number(); 
            string zipcode=Faker.Address.ZipCode();

            int newId = await contactsService.CreateCandidate(firstName, lastName, email, phoneNumber, zipcode);

            Assert.Pass();
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
            ICandidateService contactsService = new CandidateService();
            int newId = await contactsService.CreateCandidate("Edwin", "Rojas", "edwin.frederick@gmail.com", "+59175371862", "0591");
            CancellationToken
            Assert.Pass();
        }

        /// <summary>
        /// 3) Pre-population of Candidates 
        ///         a.To help both YOU and US verify your work and verify that search works, pre-populate
        ///         some candidates with various properties.This can be done within the code / in memory for
        /// this exercise, in order to save time.
        /// </summary>
        [Test]
        public void Test_C_01_SearchCandidates()
        {
            Assert.Pass();
        }
    }
}