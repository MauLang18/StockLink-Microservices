using MediatR;
using StockLink.Softland.Application.Dto.Articulo.Response;
using StockLink.Softland.Application.Interface.Interfaces;
using StockLink.Softland.Application.UseCase.Commons.Bases;
using StockLink.Softland.Utilities.Constants;

namespace StockLink.Softland.Application.UseCase.UseCase.Articulo.Queries.GetAllQuery
{
    public class GetAllArticuloFamiliaHandle : IRequestHandler<GetAllArticuloQuery, BaseResponse<IEnumerable<GetAllArticuloResponseDto>>>
    {
        private readonly IArticuloRepository _articuloRepository;

        public GetAllArticuloFamiliaHandle(IArticuloRepository articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }

        public async Task<BaseResponse<IEnumerable<GetAllArticuloResponseDto>>> Handle(GetAllArticuloQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllArticuloResponseDto>>();

            try
            {
                var parametros = new
                {
                    DESC = request.DESC,
                    PRIV = request.PRIV,
                    ORDER = request.ORDER,
                };

                var exams = await _articuloRepository.GetAllArticulos(SP.paListaArticuloFamilia, parametros);

                if (exams is not null)
                {
                    response.IsSuccess = true;
                    response.Data = exams;
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