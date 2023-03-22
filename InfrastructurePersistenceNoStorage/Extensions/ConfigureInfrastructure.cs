using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Persistence.Extensions
{
    public static class ConfigureInfrastructure
    {

        public static IServiceCollection UseInfrastructurePersistence(this IServiceCollection services, IConfiguration config )
        {
            /*
            services.AddDbContext<MyContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("AccountsDB"));
            });
            */
            /*services.AddTransient<IClientesRepository, ClientesRepository>();
            services.AddTransient<ICuentasRepository, CuentasRepository>();
            services.AddTransient<IMovimientosRepository, MovimientosRepository>();

            services.AddScoped<IDbContextTransaction>(provider =>
                provider.GetService<MyContext>().Database.BeginTransaction()
            );
            */


            return services;
        }
    }
}
