using MassTransit;
using Microsoft.Extensions.Logging;
using StockLink.Compra.Application.Interface.Interfaces;
using StockLink.Shared.Entities;

namespace StockLink.Compra.Application.UseCase.Services
{
    public class PublisherHubService : IPublisherHubService
    {
        private readonly ILogger<PublisherHubService> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public PublisherHubService(ILogger<PublisherHubService> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendNotification(int Id,string CodigoCliente, string Cliente, string CodigoArticulo, string Articulo, string Vendedor, int Cantidad, int EstadoPedido, DateTime FechaPedido, string Observacion, string Despacho)
        {
            _logger.LogInformation($"Pedido para {CodigoCliente} enviado, observacion {Observacion}");
            await _publishEndpoint.Publish(new PedidoHubRecord(Id, CodigoCliente, Cliente, CodigoArticulo, Articulo, Vendedor, Cantidad, EstadoPedido, FechaPedido, Observacion, Despacho));
        }
    }
}