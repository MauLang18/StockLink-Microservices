using FluentValidation;
using StockLink.Cotizacion.Domain.Entities;

namespace StockLink.Cotizacion.Application.Validators.DetalleCotizaciones
{
    public class DetalleCotizacionValidator : AbstractValidator<DetalleCotizacion>
    {
        public DetalleCotizacionValidator()
        {
            RuleFor(x => x.CodigoArticulo)
                .NotNull().WithMessage("El campo CODIGO ARTICULO no puede ser nulo")
                .NotEmpty().WithMessage("El campo CODIGO ARTICULO no puede estar vacio");
        }
    }
}