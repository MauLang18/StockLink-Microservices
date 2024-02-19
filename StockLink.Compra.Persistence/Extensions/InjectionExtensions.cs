using Microsoft.Extensions.DependencyInjection;
using StockLink.Compra.Application.Interface.Interfaces;
using StockLink.Compra.Persistence.Context;
using StockLink.Compra.Persistence.Repositories;

namespace StockLink.Compra.Persistence.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDbContext>();

            services.AddScoped<ICarritoCompraRepository, CarritoCompraRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}