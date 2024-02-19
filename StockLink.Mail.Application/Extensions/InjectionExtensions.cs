using Microsoft.Extensions.DependencyInjection;
using StockLink.Mail.Application.Interfaces;
using StockLink.Mail.Application.Services;

namespace StockLink.Mail.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services)
        {
            services.AddScoped<ISendEmailApplication, SendEmailApplication>();

            return services;
        }
    }
}