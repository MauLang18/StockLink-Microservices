using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockLink.Compra.Application.UseCase.UseCase.CarritoCompra.Commands.CreateCommand;
using StockLink.Compra.Application.UseCase.UseCase.CarritoCompra.Commands.DeleteByVendedorCommand;
using StockLink.Compra.Application.UseCase.UseCase.CarritoCompra.Commands.DeleteCommand;
using StockLink.Compra.Application.UseCase.UseCase.CarritoCompra.Commands.UpdateCommand;
using StockLink.Compra.Application.UseCase.UseCase.CarritoCompra.Queries.GetAllQueryByVendedor;

namespace StockLink.Compra.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarritoCompraController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet]
        /*public async Task<IActionResult> ListCarritoCompra()
        {
            var response = await _mediator.Send(new GetAllAnalysisQuery());

            return Ok(response);
        }*/

        [HttpGet("Usuario")]
        public async Task<IActionResult> ListCarritoCompraByVendedor([FromQuery] string vendedor)
        {
            var response = await _mediator.Send(new GetAllQueryByVendedorQuery() { Vendedor = vendedor });

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterCarritoCompra([FromBody] CreateCarritoCompraCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut("Edit/Cantidad")]
        public async Task<IActionResult> EditAnalysis([FromBody] UpdateCarritoCompraCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete("Remove/{id:int}")]
        public async Task<IActionResult> RemoveAnalysis(int id)
        {
            var response = await _mediator.Send(new DeleteCarritoCompraCommand() { Id = id });

            return Ok(response);
        }

        [HttpDelete("Remove/Vendedor/")]
        public async Task<IActionResult> RemoveByVendedorAnalysis(string vendedor)
        {
            var response = await _mediator.Send(new DeleteCarritoCompraByVendedorCommand() { Vendedor = vendedor });

            return Ok(response);
        }
    }
}