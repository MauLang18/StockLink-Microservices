using Microsoft.AspNetCore.Mvc;
using StockLink.Cotizacion.Application.Dtos.Cotizacion.Request;
using StockLink.Cotizacion.Application.Interfaces;
using StockLink.Cotizacion.Infrastructure.Commons.Bases.Request;

namespace StockLink.Cotizacion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {
        private readonly ICotizacionApplication _cotizacionApplication;

        public CotizacionController(ICotizacionApplication cotizacionApplication)
        {
            _cotizacionApplication = cotizacionApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ListCotizacions([FromQuery] BaseFiltersRequest filters)
        {
            var response = await _cotizacionApplication.ListCotizaciones(filters);

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> CotizacionById(int id)
        {
            var response = await _cotizacionApplication.CotizacionById(id);

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterCotizacion([FromBody] CotizacionRequestDto requestDto)
        {
            var response = await _cotizacionApplication.RegisterCotizacion(requestDto);

            return Ok(response);
        }

        [HttpPut("Edit/{id:int}")]
        public async Task<IActionResult> EditCotizacion(int id, [FromBody] CotizacionRequestDto requestDto)
        {
            var response = await _cotizacionApplication.EditCotizacion(id, requestDto);

            return Ok(response);
        }

        [HttpPut("Remove/{id:int}")]
        public async Task<IActionResult> RemoveCotizacion(int id)
        {
            var response = await _cotizacionApplication.RemoveCotizacion(id);

            return Ok(response);
        }
    }
}