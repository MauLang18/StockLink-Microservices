using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockLink.Softland.Application.UseCase.UseCase.Articulo.Queries.GetAllQuery;

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
        public async Task<IActionResult> ListArticulos([FromQuery] string desc, string priv, string order)
        {
            var response = await _mediator.Send(new GetAllArticuloQuery() { DESC = desc, PRIV = priv, ORDER = order });

            return Ok(response);
        }
    }
}