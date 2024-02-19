using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockLink.Softland.Application.UseCase.UseCase.Cliente.Queries.GetAllQuery;

namespace StockLink.Softland.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListCliente([FromQuery] string clie)
        {
            var response = await _mediator.Send(new GetAllClienteQuery() { CLIE = clie });

            return Ok(response);
        }
    }
}