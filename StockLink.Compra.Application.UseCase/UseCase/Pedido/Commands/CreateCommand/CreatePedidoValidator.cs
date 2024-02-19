using FluentValidation;

namespace StockLink.Compra.Application.UseCase.UseCase.Pedido.Commands.CreateCommand
{
    public class CreatePedidoValidator : AbstractValidator<CreatePedidoCommand>
    {
        public CreatePedidoValidator()
        {
            RuleFor(x => x.CodigoArticulo)
                .NotNull().WithMessage("El campo ARTICULO no puede ser nulo.")
                .NotEmpty().WithMessage("El campo ARTICULO no puede ser vacío.");

            RuleFor(x => x.CodigoCliente)
                .NotNull().WithMessage("El campo CLIENTE no puede ser nulo.")
                .NotEmpty().WithMessage("El campo CLIENTE no puede ser vacío.");

            RuleFor(x => x.Vendedor)
                .NotNull().WithMessage("El campo VENDEDOR no puede ser nulo.")
                .NotEmpty().WithMessage("El campo VENDEDOR no puede ser vacío.");

            RuleFor(x => x.Cantidad)
                .NotNull().WithMessage("El campo CANTIDAD no puede ser nulo.")
                .NotEmpty().WithMessage("El campo CANTIDAD no puede ser vacío.");
        }
    }
}