using MassTransit;
using Microsoft.Extensions.Logging;
using StockLink.Cotizacion.Application.Dtos.DetalleCotizacion.Response;
using StockLink.Cotizacion.Application.Interfaces;
using StockLink.Shared.Entities;

namespace StockLink.Cotizacion.Application.Services
{
    public class PublisherServices : IPublisherServices
    {
        private readonly ILogger<PublisherServices> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public PublisherServices(ILogger<PublisherServices> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendNotification(string data)
        {
            _logger.LogInformation("Notificación enviada correctamente.");

            await _publishEndpoint.Publish(new ReportCotizacionRecord(data));
        }
    }
}