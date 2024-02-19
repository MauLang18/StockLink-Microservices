using MediatR;
using StockLink.Softland.Application.Dto.Familia.Response;
using StockLink.Softland.Application.Interface.Interfaces;
using StockLink.Softland.Application.UseCase.Commons.Bases;
using StockLink.Softland.Utilities.Constants;

namespace StockLink.Softland.Application.UseCase.UseCase.Familias.Queries.GetAllQuery
{
    public class GetAllFamiliasHandle : IRequestHandler<GetAllFamiliasQuery, BaseResponse<IEnumerable<GetAllFamiliaResponseDto>>>
    {
        private readonly IFamiliasRepository _familiasRepository;

        public GetAllFamiliasHandle(IFamiliasRepository familiasRepository)
        {
            _familiasRepository = familiasRepository;
        }

        public async Task<BaseResponse<IEnumerable<GetAllFamiliaResponseDto>>> Handle(GetAllFamiliasQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllFamiliaResponseDto>>();

            try
            {
                var familias = await _familiasRepository.GetAllFamilias(SP.paListaFamilias, request);

                if (familias is not null)
                {
                    response.IsSuccess = true;
                    response.Data = familias;
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