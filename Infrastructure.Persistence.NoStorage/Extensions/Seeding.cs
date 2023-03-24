using Core.Contacts.Domain.Models;
using Core.Contacts.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Extensions
{
    public static class Seeding
    {
        public static async Task SeedCandidateNoStorage(this IServiceProvider serviceProvider)
        {
            var serviceScopeFactory = (IServiceScopeFactory)serviceProvider.GetService(typeof(IServiceScopeFactory));

            using (IServiceScope scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ICandidateRepository>();

                for (int i = 0; i < 1000; i++)
                {
                    string firstName = Faker.Name.First();
                    string lastName = Faker.Name.Last();
                    Regex rgx = new Regex("[^a-zA-Z0-9]");
                    string company = rgx.Replace(Faker.Company.Name(), "");
                    string email = $"{Faker.Name.First()}.{Faker.Name.Last()}@{company}.com";
                    string phoneNumber = Faker.Phone.Number();
                    string zipcode = Faker.Address.ZipCode();
                    var contact = new MCandidate(firstName, lastName, email, phoneNumber, zipcode);
                    await context.CreateAsync(firstName, lastName, email, phoneNumber, zipcode);
                }
            }
        }
    }
}
