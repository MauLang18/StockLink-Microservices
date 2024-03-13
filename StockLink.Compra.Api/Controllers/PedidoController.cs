using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockLink.Compra.Application.Interface.Interfaces;
using StockLink.Compra.Application.UseCase.UseCase.Pedido.Commands.ChangeStateCommand;
using StockLink.Compra.Application.UseCase.UseCase.Pedido.Commands.CreateCommand;
using StockLink.Compra.Application.UseCase.UseCase.Pedido.Queries.GetAllQuery;
using StockLink.Compra.Application.UseCase.UseCase.Pedido.Queries.GetAllQueryEnviado;

namespace StockLink.Compra.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPublisherEmailService _publisherEmailService;
        private readonly IPublisherHubService _publisherHubService;

        private string? NombreCliente;
        private string? CodigoCliente;
        private string? Observacion;
        private string? Correo;

        public PedidoController(IMediator mediator, IPublisherEmailService publisherEmailService, IPublisherHubService publisherHubService)
        {
            _mediator = mediator;
            _publisherEmailService = publisherEmailService;
            _publisherHubService = publisherHubService;
        }

        [HttpGet]
        public async Task<IActionResult> ListPedido([FromQuery] int estado)
        {
            var response = await _mediator.Send(new GetAllPedidoQuery());

            return Ok(response);
        }

        [HttpGet("Estado")]
        public async Task<IActionResult> ListPedidoEstado([FromQuery] string codigoCliente, string vendedor, DateTime fechaPedido, string despacho)
        {
            var response = await _mediator.Send(new GetAllQueryEnviadoQuery() { CodigoCliente = codigoCliente, Vendedor = vendedor, FechaPedido = fechaPedido });

            foreach (var item in response.Data!)
            {
                NombreCliente = item.Cliente;
                CodigoCliente = item.CodigoCliente;
                Observacion = item.Observacion;
                Correo += $"<li><strong>Codigo:</strong> {item.CodigoArticulo} - <strong>Producto:</strong> {item.Articulo} - <strong>Cantidad:</strong> {item.Cantidad}</li>";
            }

            var contenido = GenerarContenidoCorreo(NombreCliente!, CodigoCliente!, Observacion!, Correo!);

            await _publisherEmailService.SendNotification($"{despacho}",$"{vendedor}",$"Pedido para {CodigoCliente} - {NombreCliente} / vendedor {vendedor}",contenido);

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterPedido([FromBody] CreatePedidoCommand command)
        {
            var response = await _mediator.Send(command);

            await _publisherHubService.SendNotification(0, command.CodigoCliente!,command.Cliente!,command.CodigoArticulo!,command.Articulo!,command.Vendedor!,command.Cantidad,command.EstadoPedido,DateTime.Now,command.Observacion!);

            return Ok(response);
        }

        [HttpPut("Edit/Estado")]
        public async Task<IActionResult> EditPedido([FromBody] ChangeStatePedidoCommand command)
        {
            var response = await _mediator.Send(command);

            await _publisherHubService.SendNotification(command.Id, "", "", "", "", "", 0, command.EstadoPedido, DateTime.Now, "");

            return Ok(response);
        }

        private string GenerarContenidoCorreo(string nombreCliente, string codigo, string obser, string response)
        {
            string correoHTML = $"<h1>Detalles del Pedido para {codigo} - {nombreCliente}</h1><ul>";

            correoHTML += $"{response}";

            correoHTML += "</ul>";

            correoHTML += $"<p><strong>Observaciones:</strong> {obser}</p>";

            return correoHTML;
        }
    }
}