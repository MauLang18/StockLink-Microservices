using StockLink.Cotizacion.Application.Dtos.DetalleCotizacion.Response;

namespace StockLink.Cotizacion.Application.Interfaces
{
    public interface IPublisherServices
    {
        Task SendNotification(string data);
    }
}