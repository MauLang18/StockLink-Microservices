﻿using ClosedXML.Excel;
using StockLink.Reports.Infrastructure.Commons.Bases.Response;
using StockLink.Reports.Utilities.Static;

namespace StockLink.Reports.Infrastructure.FileExcel
{
    public class GenerateExcel : IGenerateExcel
    {
        public MemoryStream GenerateToExcel<T>(BaseEntityResponse<T> data, List<TableColumns> columns)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Listado");

            for (int i = 0; i < columns.Count; i++)
            {
                worksheet.Cell(1, i + 1).Value = columns[i].Label;
            }

            var rowIndex = 2;

            foreach (var item in data.Items!)
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    var propertyValue = typeof(T).GetProperty(columns[i].PropertyName!)?.GetValue(item)?.ToString();
                    worksheet.Cell(rowIndex, i + 1).Value = propertyValue;
                }

                rowIndex++;
            }

            var stream = new MemoryStream();
            workbook.SaveAs(stream);

            stream.Position = 0;

            return stream;
        }
    }
}