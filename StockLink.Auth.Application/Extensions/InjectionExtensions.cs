using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockLink.Auth.Application.Interfaces;
using StockLink.Auth.Application.Services;
using System.Reflection;

namespace StockLink.Auth.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplications(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IUsuarioApplication, UsuarioApplication>();
            services.AddScoped<IAuthApplication, AuthApplication>();
            services.AddScoped<IRolApplication, RolApplication>();

            return services;
        }
    }
}