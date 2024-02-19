using FluentValidation;
using StockLink.Compra.Application.UseCase.UseCase.CarritoCompra.Commands.CreateCommand;

namespace StockLink.Compra.Application.UseCase.UseCase.CarritoCompra.Commands.CreateCommand
{
    public class CreateCarritoCompraValidator : AbstractValidator<CreateCarritoCompraCommand>
    {
        public CreateCarritoCompraValidator()
        {
            RuleFor(x => x.CodigoArticulo)
                .NotNull().WithMessage("El campo ARTICULO no puede ser nulo.")
                .NotEmpty().WithMessage("El campo ARTICULO no puede ser vacío.");

            RuleFor(x => x.Vendedor)
                .NotNull().WithMessage("El campo VENDEDOR no puede ser nulo.")
                .NotEmpty().WithMessage("El campo VENDEDOR no puede ser vacío.");

            RuleFor(x => x.Cantidad)
                .NotNull().WithMessage("El campo CANTIDAD no puede ser nulo.")
                .NotEmpty().WithMessage("El campo CANTIDAD no puede ser vacío.");
        }
    }
}