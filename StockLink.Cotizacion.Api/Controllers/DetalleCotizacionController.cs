using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;
using StockLink.Cotizacion.Application.Dtos.DetalleCotizacion.Request;
using StockLink.Cotizacion.Application.Interfaces;
using StockLink.Cotizacion.Infrastructure.Commons.Bases.Request;

namespace StockLink.Cotizacion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCotizacionController : ControllerBase
    {
        private readonly IDetalleCotizacionApplication _detalleCotizacionApplication;
        private readonly IPublisherServices _publisherServices;

        public DetalleCotizacionController(IDetalleCotizacionApplication detalleCotizacionApplication, IPublisherServices publisherServices)
        {
            _detalleCotizacionApplication = detalleCotizacionApplication;
            _publisherServices = publisherServices;
        }

        [HttpGet]
        public async Task<IActionResult> ListDetalleCotizacions([FromQuery] BaseFiltersRequest filters)
        {
            var response = await _detalleCotizacionApplication.ListDetallesCotizaciones(filters);

            return Ok(response);
        }

        [HttpGet("Report/{id:int}")]
        public async Task<IActionResult> ReportCotizacion(int id)
        {
            var redisConnection = ConnectionMultiplexer.Connect("190.113.124.155:6379");
            var response = await _detalleCotizacionApplication.ReportCotizacion(id);

            await _publisherServices.SendNotification(JsonConvert.SerializeObject(response.Data!));

            var uniqueKey = id.ToString();
            var database = redisConnection.GetDatabase();
            var pdfBytesRedisValue = database.StringGet(uniqueKey);
            byte[] pdfBytes = (byte[])pdfBytesRedisValue!;

            return File(pdfBytes, "application/pdf");
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> DetalleCotizacionById(int id)
        {
            var response = await _detalleCotizacionApplication.DetalleCotizacionById(id);

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterDetalleCotizacion([FromBody] DetalleCotizacionRequestDto requestDto)
        {
            var response = await _detalleCotizacionApplication.RegisterDetalleCotizacion(requestDto);

            return Ok(response);
        }

        [HttpPut("Edit/{id:int}")]
        public async Task<IActionResult> EditDetalleCotizacion(int id, [FromBody] DetalleCotizacionRequestDto requestDto)
        {
            var response = await _detalleCotizacionApplication.EditDetalleCotizacion(id, requestDto);

            return Ok(response);
        }

        [HttpPut("Remove/{id:int}")]
        public async Task<IActionResult> RemoveDetalleCotizacion(int id)
        {
            var response = await _detalleCotizacionApplication.RemoveDetalleCotizacion(id);

            return Ok(response);
        }
    }
}