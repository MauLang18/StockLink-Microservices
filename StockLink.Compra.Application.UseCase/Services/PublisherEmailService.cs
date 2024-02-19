using MassTransit;
using Microsoft.Extensions.Logging;
using StockLink.Compra.Application.Interface.Interfaces;
using StockLink.Shared.Entities;

namespace StockLink.Compra.Application.UseCase.Services
{
    public class PublisherEmailService : IPublisherEmailService
    {
        private readonly ILogger<PublisherEmailService> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public PublisherEmailService(ILogger<PublisherEmailService> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendNotification(string Para, string Cc, string Asunto, string Contenido)
        {
            _logger.LogInformation($"Correo enviado para {Para} con copia para {Cc}, asunto {Asunto}");
            await _publishEndpoint.Publish(new PedidoMailRecord(Para, Cc, Asunto, Contenido));
        }
    }
}