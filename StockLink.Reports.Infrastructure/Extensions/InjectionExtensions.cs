using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockLink.Reports.Infrastructure.FileExcel;
using StockLink.Reports.Infrastructure.FilePdf;

namespace StockLink.Reports.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IGenerateExcel, GenerateExcel>();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            services.AddTransient<IGeneratePdf, GeneratePdf>();

            return services;
        }
    }
}