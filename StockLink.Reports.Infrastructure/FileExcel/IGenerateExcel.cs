using StockLink.Reports.Infrastructure.Commons.Bases.Response;
using StockLink.Reports.Utilities.Static;

namespace StockLink.Reports.Infrastructure.FileExcel
{
    public interface IGenerateExcel
    {
        MemoryStream GenerateToExcel<T>(BaseEntityResponse<T> data, List<TableColumns> columns);
    }
}