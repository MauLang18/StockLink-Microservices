using MassTransit;
using Microsoft.AspNetCore.SignalR;
using StockLink.Hubs.Api.Hubs;
using StockLink.Shared.Entities;

namespace StockLink.Hubs.Api.Services
{
    public class PedidoConsumerService : IConsumer<PedidoHubRecord>
    {
        private readonly ILogger<PedidoConsumerService> _logger;
        private readonly IHubContext<StockLinkHubs> _hubContext;

        public PedidoConsumerService(ILogger<PedidoConsumerService> logger, IHubContext<StockLinkHubs> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        public Task Consume(ConsumeContext<PedidoHubRecord> context)
        {
            _logger.LogInformation($"Pedido para {context.Message.CodigoCliente} recibido, observacion {context.Message.Observacion}");

            if (context.Message.Id == 0)
            {
                _hubContext.Clients.Group(context.Message.Despacho).SendAsync("PedidoRegistrado", context.Message);
            }
            else
            {
                _hubContext.Clients.Group(context.Message.Despacho).SendAsync("PedidoActualizado", context.Message);
            }

            return Task.CompletedTask;
        }
    }
}
