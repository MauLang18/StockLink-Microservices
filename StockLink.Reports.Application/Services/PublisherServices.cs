using MassTransit;
using Microsoft.Extensions.Logging;
using StockLink.Reports.Application.Interfaces;
using StockLink.Shared.Entities;

namespace StockLink.Reports.Application.Services
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

        public async Task SendNotification(int Id)
        {
            _logger.LogInformation("Notificación enviada correctamente.");

            await _publishEndpoint.Publish(new ReportResultCotizacionRecord(Id));
        }
    }
}