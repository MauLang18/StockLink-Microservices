namespace StockLink.Reports.Application.Interfaces
{
    public interface IPublisherServices
    {
        Task SendNotification(int Id);
    }
}