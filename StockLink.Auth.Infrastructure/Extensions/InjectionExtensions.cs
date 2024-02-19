using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockLink.Auth.Infrastructure.Persistences.Contexts;
using StockLink.Auth.Infrastructure.Persistences.Interfaces;
using StockLink.Auth.Infrastructure.Persistences.Repository;

namespace StockLink.Auth.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(UsuariosContext).Assembly.FullName;

            services.AddDbContext<UsuariosContext>(
                options => options.UseSqlServer(
                       configuration.GetConnectionString("Connection"), b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}