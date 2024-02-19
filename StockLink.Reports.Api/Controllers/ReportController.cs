using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;
using StockLink.Cotizacion.Application.Dtos.DetalleCotizacion.Response;
using StockLink.Reports.Application.Interfaces;

namespace StockLink.Reports.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IPublisherServices _publisherServices;
        private readonly IGeneratePdfApplication _generatePdfApplication;

        public ReportController(IPublisherServices publisherServices, IGeneratePdfApplication generatePdfApplication)
        {
            _publisherServices = publisherServices;
            _generatePdfApplication = generatePdfApplication;
        }

        [HttpGet("Cotizacion/{id:int}")]
        public async Task<IActionResult> CotizacionReport(int id)
        {
            await _publisherServices.SendNotification(id);

            await Task.Delay(5000);

            var redisConnection = ConnectionMultiplexer.Connect("redis:6379");

            var uniqueKey = id.ToString();
            var database = redisConnection.GetDatabase();
            var datos = database.StringGet(uniqueKey);

            byte[] pdfBytes;
            string titulo = "";
            string contenidoPlantilla = "";
            string nombreArchivo = "";

            try
            {
                var data1List = JsonConvert.DeserializeObject<List<ReportCotizacionResponseDto>>(datos!);
                var data = data1List!.FirstOrDefault();

                if (string.IsNullOrEmpty(data!.Tipo))
                {
                    Console.WriteLine("Error: Tipo de reporte no proporcionado.");
                    return null!;
                }

                string rutaPlantilla = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Static/Template", $"{data.Tipo}.html"); //"/app/bin/Debug/net8.0/Static/Template/cotizacion.html"

                if (!System.IO.File.Exists(rutaPlantilla))
                {
                    Console.WriteLine($"Error: La plantilla para el tipo {data.Tipo} no existe. Ruta esperada: {rutaPlantilla}");
                    return null!;
                }

                contenidoPlantilla = System.IO.File.ReadAllText(rutaPlantilla);
                titulo = "prueba";

                // Reemplazar datos de Cliente, Vendedor y Fecha
                contenidoPlantilla = contenidoPlantilla
                    .Replace("cliente", data.Cliente)
                    .Replace("vendedor", data.Vendedor)
                    .Replace("fecha", DateTime.Now.ToString());

                // Iterar sobre detalles y llenar la tabla
                string detallesTabla = "";
                decimal totalAcumulado = 0;

                foreach (var detalle in data1List!)
                {
                    decimal totalDetalle = detalle.Cantidad * detalle.Precio;

                    totalAcumulado += totalDetalle;

                    detallesTabla += $@"
            <tr>
                <td>{detalle.Articulo}</td>
                <td>{detalle.Cantidad}</td>
                <td>₡{detalle.Precio}</td>
                <td>₡{totalDetalle}</td>
            </tr>";
                }

                contenidoPlantilla = contenidoPlantilla
                    .Replace("<!--DetallesTabla-->", detallesTabla) // Marca en el HTML para reemplazar con detalles
                    .Replace("total", "₡" + totalAcumulado.ToString());

                nombreArchivo = $"{data.IdCotizacion}-{data.Cliente}-{DateTime.Now.ToString()}.pdf";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            pdfBytes = _generatePdfApplication.GenerateToPdf(titulo, contenidoPlantilla);

            return File(pdfBytes, "application/pdf", nombreArchivo);
        }
    }
}
