using AutoMapper;
using MediatR;
using StockLink.Compra.Application.Interface.Interfaces;
using StockLink.Compra.Application.UseCase.Commons.Bases;
using StockLink.Compra.Utilities.Constants;
using StockLink.Compra.Utilities.HelperExtensions;
using Entity = StockLink.Compra.Domain.Entities;

namespace StockLink.Compra.Application.UseCase.UseCase.Pedido.Commands.ChangeStateCommand
{
    public class ChangeStatePedidoHandle : IRequestHandler<ChangeStatePedidoCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeStatePedidoHandle(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(ChangeStatePedidoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var pedido = _mapper.Map<Entity.Pedido>(request);
                var parameters = pedido.GetPropertiesWithValues();
                response.Data = await _unitOfWork.Pedido.ExecAsync(SP.paChangeStatePedido, parameters);

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