using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockLink.Cotizacion.Infrastructure.Persistences.Contexts;
using StockLink.Cotizacion.Infrastructure.Persistences.Interfaces;
using StockLink.Cotizacion.Infrastructure.Persistences.Repository;

namespace StockLink.Cotizacion.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(PedidosContext).Assembly.FullName;

            services.AddDbContext<PedidosContext>(
                options => options.UseSqlServer(
                       configuration.GetConnectionString("Connection"), b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}