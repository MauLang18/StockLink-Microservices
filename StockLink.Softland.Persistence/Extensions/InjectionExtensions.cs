using Microsoft.Extensions.DependencyInjection;
using StockLink.Softland.Application.Interface.Interfaces;
using StockLink.Softland.Persistence.Context;
using StockLink.Softland.Persistence.Repositories;

namespace StockLink.Softland.Persistence.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDbContext>();

            services.AddScoped<IArticuloRepository, ArticuloRepository>();
            services.AddScoped<IFamiliasRepository, FamiliasRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            return services;
        }
    }
}