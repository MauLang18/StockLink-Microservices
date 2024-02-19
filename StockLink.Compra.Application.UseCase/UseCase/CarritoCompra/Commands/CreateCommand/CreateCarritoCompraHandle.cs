using AutoMapper;
using MediatR;
using StockLink.Compra.Application.Interface.Interfaces;
using StockLink.Compra.Application.UseCase.Commons.Bases;
using StockLink.Compra.Application.UseCase.UseCase.CarritoCompra.Commands.CreateCommand;
using StockLink.Compra.Utilities.Constants;
using StockLink.Compra.Utilities.HelperExtensions;
using Entity = StockLink.Compra.Domain.Entities;

namespace StockLink.Compra.Application.UseCase.UseCase.CarritoCompra.Commands.CreateCommand
{
    public class CreateCarritoCompraHandle : IRequestHandler<CreateCarritoCompraCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCarritoCompraHandle(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateCarritoCompraCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var carritoCompra = _mapper.Map<Entity.CarritoCompra>(request);
                var parameters = carritoCompra.GetPropertiesWithValues();
                response.Data = await _unitOfWork.CarritoCompra.ExecAsync(SP.paRegisterCarritoCompra, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessage.MESSAGE_SAVE;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}