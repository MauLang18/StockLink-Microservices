using StockLink.Reports.Application.Interfaces;
using StockLink.Reports.Infrastructure.Commons.Bases.Response;
using StockLink.Reports.Infrastructure.FileExcel;
using StockLink.Reports.Utilities.Static;

namespace StockLink.Reports.Application.Services
{
    public class GenerateExcelApplication : IGenerateExcelApplication
    {
        private readonly IGenerateExcel _generateExcel;

        public GenerateExcelApplication(IGenerateExcel generateExcel)
        {
            _generateExcel = generateExcel;
        }

        public byte[] GenerateToExcel<T>(BaseEntityResponse<T> data, List<(string ColumnName, string PropertyName)> columns)
        {
            var excelColumns = ExcelColumnNames.GetColumns(columns);
            var memoryStreamExcel = _generateExcel.GenerateToExcel(data, excelColumns);
            var fileBytes = memoryStreamExcel.ToArray();

            return fileBytes;
        }
    }
}