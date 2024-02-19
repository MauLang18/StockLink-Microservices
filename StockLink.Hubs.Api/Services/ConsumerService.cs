using MassTransit;
using Microsoft.AspNetCore.SignalR;
using StockLink.Hubs.Api.Hubs;
using StockLink.Shared.Entities;

namespace StockLink.Hubs.Api.Services
{
    public class ConsumerService : IConsumer<PedidoHubRecord>
    {
        private readonly ILogger<ConsumerService> _logger;
        private readonly IHubContext<StockLinkHubs> _hubContext;

        public ConsumerService(ILogger<ConsumerService> logger, IHubContext<StockLinkHubs> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        public Task Consume(ConsumeContext<PedidoHubRecord> context)
        {
            _logger.LogInformation($"Pedido para {context.Message.CodigoCliente} recibido, observacion {context.Message.Observacion}");

            if (context.Message.Id == 0)
            {
                _hubContext.Clients.All.SendAsync("PedidoRegistrado", context.Message);
            }
            else
            {
                _hubContext.Clients.All.SendAsync("PedidoActualizado", context.Message);
            }

            return Task.CompletedTask;
        }
    }
}
