using Core.Contacts.Interfaces;
using Infrastructure.Persistence.NoStorage.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Persistence.Extensions
{
    public static class ConfigureInfrastructure
    {

        public static IServiceCollection UseInfrastructurePersistence(this IServiceCollection services, IConfiguration config )
        {
         

            services.AddSingleton<ICandidateRepository, CandidateRepository>();
            return services;
        }
    }
}
