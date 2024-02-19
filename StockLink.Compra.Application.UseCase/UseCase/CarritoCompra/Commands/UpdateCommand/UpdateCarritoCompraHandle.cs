using AutoMapper;
using MediatR;
using StockLink.Compra.Application.Interface.Interfaces;
using StockLink.Compra.Application.UseCase.Commons.Bases;
using StockLink.Compra.Utilities.Constants;
using StockLink.Compra.Utilities.HelperExtensions;
using Entity = StockLink.Compra.Domain.Entities;

namespace StockLink.Compra.Application.UseCase.UseCase.CarritoCompra.Commands.UpdateCommand
{
    public class UpdateCarritoCompraHandle : IRequestHandler<UpdateCarritoCompraCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCarritoCompraHandle(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateCarritoCompraCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var carritoCompra = _mapper.Map<Entity.CarritoCompra>(request);
                var parameters = carritoCompra.GetPropertiesWithValues();
                response.Data = await _unitOfWork.CarritoCompra.ExecAsync(SP.paUpdateCarritoCompra, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessage.MESSAGE_UPDATE_STATE;
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