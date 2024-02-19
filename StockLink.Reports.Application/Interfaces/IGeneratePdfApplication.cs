namespace StockLink.Reports.Application.Interfaces
{
    public interface IGeneratePdfApplication
    {
        byte[] GenerateToPdf(string titulo, string content);
    }
}