namespace StockLink.Reports.Infrastructure.FilePdf
{
    public interface IGeneratePdf
    {
        MemoryStream GenerateToPdf(string title, string content);
    }
}