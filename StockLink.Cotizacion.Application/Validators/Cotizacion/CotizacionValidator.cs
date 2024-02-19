using FluentValidation;
using StockLink.Cotizacion.Application.Dtos.Cotizacion.Request;

namespace StockLink.Cotizacion.Application.Validators.Cotizacion
{
    public class CotizacionValidator : AbstractValidator<CotizacionRequestDto>
    {
        public CotizacionValidator()
        {
            RuleFor(x => x.CodigoCliente)
                .NotNull().WithMessage("El campo CODIGO CLIENTE no puede ser nulo")
                .NotEmpty().WithMessage("El campo CODIGO CLIENTE no puede estar vacio");
        }
    }
}