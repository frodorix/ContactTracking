using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Entity;
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
        public static IServiceProvider SeedCandidates(this IServiceProvider serviceProvider)
        {
            var serviceScopeFactory = (IServiceScopeFactory)serviceProvider.GetService(typeof(IServiceScopeFactory));

            //var context = new CandidatesContext()//serviceProvider.GetRequiredService< CandidatesContext>();


            using (IServiceScope scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<CandidatesContext>();
                
                int total = context.Candidates.Count();

                if (total < 1000)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        string firstName = Faker.Name.First();
                        string lastName = Faker.Name.Last();
                        Regex rgx = new Regex("[^a-zA-Z0-9]");
                        string company = rgx.Replace(Faker.Company.Name(), "");
                        string email = $"{Faker.Name.First()}.{Faker.Name.Last()}@{company}.com";
                        string phoneNumber = Faker.Phone.Number();
                        string zipcode = Faker.Address.ZipCode();
                        var contact = new Candidate(firstName, lastName, email, phoneNumber, zipcode);
                        context.Candidates.Add(contact);
                    }
                    context.SaveChanges();
                }
            }
            return serviceProvider;
        }
    }
}
