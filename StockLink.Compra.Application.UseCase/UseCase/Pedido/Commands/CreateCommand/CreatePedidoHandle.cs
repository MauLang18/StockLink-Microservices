using AutoMapper;
using MediatR;
using StockLink.Compra.Application.Interface.Interfaces;
using StockLink.Compra.Application.UseCase.Commons.Bases;
using StockLink.Compra.Utilities.Constants;
using StockLink.Compra.Utilities.HelperExtensions;
using Entity = StockLink.Compra.Domain.Entities;

namespace StockLink.Compra.Application.UseCase.UseCase.Pedido.Commands.CreateCommand
{
    public class CreatePedidoHandle : IRequestHandler<CreatePedidoCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePedidoHandle(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var pedidos = _mapper.Map<Entity.Pedido>(request);
                var parameters = pedidos.GetPropertiesWithValues();
                response.Data = await _unitOfWork.Pedido.ExecAsync(SP.paRegisterPedido, parameters);

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