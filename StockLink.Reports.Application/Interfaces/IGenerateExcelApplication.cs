using StockLink.Reports.Infrastructure.Commons.Bases.Response;

namespace StockLink.Reports.Application.Interfaces
{
    public interface IGenerateExcelApplication
    {
        byte[] GenerateToExcel<T>(BaseEntityResponse<T> data, List<(string ColumnName, string PropertyName)> columns);
    }
}