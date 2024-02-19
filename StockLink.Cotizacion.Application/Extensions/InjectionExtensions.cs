using FluentValidation;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockLink.Cotizacion.Application.Extensions.WatchDog;
using StockLink.Cotizacion.Application.Interfaces;
using StockLink.Cotizacion.Application.Services;
using System.Reflection;

namespace StockLink.Cotizacion.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICotizacionApplication, CotizacionApplication>();
            services.AddScoped<IDetalleCotizacionApplication, DetalleCotizacionApplication>();

            //services.AddScoped<IPublisherServices, PublisherServices>();

            services.AddWatchDog();

            return services;
        }
    }
}