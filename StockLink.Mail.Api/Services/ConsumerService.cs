using MassTransit;
using StockLink.Mail.Application.Dtos.Mail.Request;
using StockLink.Mail.Application.Interfaces;
using StockLink.Shared.Entities;

namespace StockLink.Mail.Api.Services
{
    public class ConsumerService : IConsumer<PedidoMailRecord>
    {
        private readonly ILogger<ConsumerService> _logger;
        private readonly ISendEmailApplication _sendEmailApplication;

        public ConsumerService(ILogger<ConsumerService> logger, ISendEmailApplication sendEmailApplication)
        {
            _logger = logger;
            _sendEmailApplication = sendEmailApplication;
        }

        public Task Consume(ConsumeContext<PedidoMailRecord> context)
        {
            _logger.LogInformation($"Correo recibido con copia para {context.Message.Cc}, asunto {context.Message.Asunto}");

            if (context.Message.Cc != null)
            {
                var request = new MailRequestDto();

                request.Para = context.Message.Para;
                request.Cc = context.Message.Cc;
                request.Asunto = context.Message.Asunto;
                request.Contenido = context.Message.Contenido;

                _sendEmailApplication.SendEmail(request);
            }

            return Task.CompletedTask;
        }
    }
}