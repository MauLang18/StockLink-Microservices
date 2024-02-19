namespace StockLink.Compra.Application.Interface.Interfaces
{
    public interface IPublisherEmailService
    {
        Task SendNotification(string Para, string Cc, string Asunto, string Contenido);
    }
}