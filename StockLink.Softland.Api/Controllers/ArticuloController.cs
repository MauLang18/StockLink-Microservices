using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockLink.Softland.Application.UseCase.UseCase.Articulo.Queries.GetAllQuery;
using StockLink.Softland.Application.UseCase.UseCase.Articulo.Queries.GetAllQueryFamilia;

namespace StockLink.Softland.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticuloController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListArticulos([FromQuery] string desc, string priv, string order, string drainsa, string motornova)
        {
            var response = await _mediator.Send(new GetAllArticuloQuery() { DESC = desc, PRIV = priv, ORDER = order, DRAINSA = Convert.ToInt32(drainsa), MOTORNOVA = Convert.ToInt32(motornova) });

            return Ok(response);
        }

        [HttpGet("Familia")]
        public async Task<IActionResult> ListArticulosFamilia([FromQuery] string desc, string priv, string order)
        {
            var response = await _mediator.Send(new GetAllArticuloFamiliaQuery() { DESC = desc, PRIV = priv, ORDER = order });

            return Ok(response);
        }
    }
}