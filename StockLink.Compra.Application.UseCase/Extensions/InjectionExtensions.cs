using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StockLink.Compra.Application.Interface.Interfaces;
using StockLink.Compra.Application.UseCase.Commons.Behaviours;
using StockLink.Compra.Application.UseCase.Services;
using System.Reflection;

namespace StockLink.Compra.Application.UseCase.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<IPublisherEmailService, PublisherEmailService>();
            services.AddScoped<IPublisherHubService, PublisherHubService>();

            services.AddMassTransit(conf =>
            {
                conf.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("rabbitmq3", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                });
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}