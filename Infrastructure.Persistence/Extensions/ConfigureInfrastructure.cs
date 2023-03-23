using Core.Contacts.Interfaces;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Persistence.Extensions
{
    public static class ConfigureInfrastructure
    {

        public static IServiceCollection UseInfrastructurePersistence(this IServiceCollection services, IConfiguration config )
        {

            services.AddDbContext<CandidatesContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("CandidatesDB"));
            });


            services.AddTransient<ICandidateRepository, CandidateRepository>();
            return services;
        }
    }
}
