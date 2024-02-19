using DinkToPdf;
using DinkToPdf.Contracts;

namespace StockLink.Reports.Infrastructure.FilePdf
{
    public class GeneratePdf : IGeneratePdf
    {
        private readonly IConverter _converter;

        public GeneratePdf(IConverter converter)
        {
            _converter = converter;
        }

        public MemoryStream GenerateToPdf(string title, string content)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 10, Right = 10 },
                DocumentTitle = title
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = content,
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontSize = 12, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 },
                FooterSettings = { FontSize = 12, Line = true, Right = "© " + DateTime.Now.Year }
            };

            var document = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var pdfBytes = _converter.Convert(document);

            var memoryStream = new MemoryStream(pdfBytes);

            return memoryStream;
        }
    }
}