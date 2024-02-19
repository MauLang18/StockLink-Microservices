using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockLink.Reports.Application.Interfaces;
using StockLink.Reports.Application.Services;

namespace StockLink.Reports.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddScoped<IGenerateExcelApplication, GenerateExcelApplication>();
            services.AddSingleton<IGeneratePdfApplication, GeneratePdfApplication>();

            //services.AddScoped<IPublisherServices, PublisherServices>();

            return services;
        }
    }
}