using MediatR;
using StockLink.Compra.Application.Dtos.Pedido.Response;
using StockLink.Compra.Application.Interface.Interfaces;
using StockLink.Compra.Application.UseCase.Commons.Bases;
using StockLink.Compra.Utilities.Constants;

namespace StockLink.Compra.Application.UseCase.UseCase.Pedido.Queries.GetAllQueryEnviado
{
    public class GetAllQueryEnviadoHandle : IRequestHandler<GetAllQueryEnviadoQuery, BaseResponse<IEnumerable<GetAllPedidoResponseDto>>>
    {
        private readonly IPedidoRepository _pedidoRepository;

        public GetAllQueryEnviadoHandle(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<BaseResponse<IEnumerable<GetAllPedidoResponseDto>>> Handle(GetAllQueryEnviadoQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllPedidoResponseDto>>();

            try
            {
                var parametros = new
                {
                    CodigoCliente = request.CodigoCliente,
                    Vendedor = request.Vendedor,
                    FechaPedido = request.FechaPedido
                };

                var pedidos = await _pedidoRepository.GetAllPedidosEnviado(SP.paListaPedidoByEstado, parametros);

                if (pedidos is not null)
                {
                    response.IsSuccess = true;
                    response.Data = pedidos;
                    response.Message = GlobalMessage.MESSAGE_QUERY;
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