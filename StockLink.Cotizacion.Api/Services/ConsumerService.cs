using MassTransit;
using Newtonsoft.Json;
using StackExchange.Redis;
using StockLink.Cotizacion.Application.Interfaces;
using StockLink.Shared.Entities;

namespace StockLink.Cotizacion.Api.Services
{
    public class ConsumerService : IConsumer<ReportResultCotizacionRecord>
    {
        private readonly ILogger<ConsumerService> _logger;
        private readonly IDetalleCotizacionApplication _detalleCotizacionApplication;

        public ConsumerService(ILogger<ConsumerService> logger, IDetalleCotizacionApplication detalleCotizacionApplication)
        {
            _logger = logger;
            _detalleCotizacionApplication = detalleCotizacionApplication;
        }

        public async Task Consume(ConsumeContext<ReportResultCotizacionRecord> context)
        {
            try
            {
                var redisConnection = ConnectionMultiplexer.Connect("redis:6379");

                _logger.LogInformation($"Notificación recibida correctamente. ID Cotizacion {context.Message.Id}");

                var database = redisConnection.GetDatabase();
                var uniqueKey = context.Message.Id.ToString();

                var response = await _detalleCotizacionApplication.ReportCotizacion(context.Message.Id);

                database.StringSet(uniqueKey, JsonConvert.SerializeObject(response.Data), TimeSpan.FromSeconds(10));
            }catch(Exception ex)
            {
                _logger.LogError(ex, $"Error al procesar la notificación. ID Cotizacion {context.Message.Id}");
            }
        }
    }
}
