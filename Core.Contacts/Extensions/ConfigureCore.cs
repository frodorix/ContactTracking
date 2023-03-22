using Core.Contacts.Application;
using Core.Contacts.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Persistence.Extensions
{
    public static class ConfigureCore
    {

        public static IServiceCollection UseCoreServices(this IServiceCollection services)
        {

            services.AddTransient<ICandidateService, CandidateService>();

            return services;
        }
    }
}
