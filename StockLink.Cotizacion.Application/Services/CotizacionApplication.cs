using AutoMapper;
using Newtonsoft.Json;
using StockLink.Cotizacion.Application.Commons.Bases;
using StockLink.Cotizacion.Application.Dtos.Cotizacion.Request;
using StockLink.Cotizacion.Application.Dtos.Cotizacion.Response;
using StockLink.Cotizacion.Application.Interfaces;
using StockLink.Cotizacion.Domain.Entities;
using StockLink.Cotizacion.Infrastructure.Commons.Bases.Request;
using StockLink.Cotizacion.Infrastructure.Commons.Bases.Response;
using StockLink.Cotizacion.Infrastructure.Persistences.Interfaces;
using StockLink.Cotizacion.Utilities.Static;

namespace StockLink.Cotizacion.Application.Services
{
    public class CotizacionApplication : ICotizacionApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CotizacionApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<BaseEntityResponse<CotizacionResponseDto>>> ListCotizaciones(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<CotizacionResponseDto>>();
            try
            {
                var Cotizacions = await _unitOfWork.Cotizacion.ListCotizaciones(filters);

                if (Cotizacions is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<BaseEntityResponse<CotizacionResponseDto>>(Cotizacions);
                    response.Message = ReplyMessage.MESSAGE_QUERY;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                }
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
            }

            return response;
        }

        public async Task<BaseResponse<CotizacionResponseDto>> CotizacionById(int id)
        {
            var response = new BaseResponse<CotizacionResponseDto>();
            try
            {
                var Cotizacion = await _unitOfWork.Cotizacion.GetByIdAsync(id);

                if (Cotizacion is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<CotizacionResponseDto>(Cotizacion);
                    response.Message = ReplyMessage.MESSAGE_QUERY;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                }
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> RegisterCotizacion(CotizacionRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var Cotizacion = _mapper.Map<Cotizaciones>(requestDto);
                response.Data = await _unitOfWork.Cotizacion.RegisterAsync(Cotizacion);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = ReplyMessage.MESSAGE_SAVE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                }
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> EditCotizacion(int id, CotizacionRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var CotizacionEdit = await CotizacionById(id);

                if (CotizacionEdit.Data is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                var Cotizacion = _mapper.Map<Cotizaciones>(requestDto);
                Cotizacion.Id = id;
                response.Data = await _unitOfWork.Cotizacion.EditAsync(Cotizacion);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = ReplyMessage.MESSAGE_UPDATE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                }
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> RemoveCotizacion(int id)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var Cotizacion = await CotizacionById(id);

                if (Cotizacion.Data is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                response.Data = await _unitOfWork.Cotizacion.RemoveAsync(id);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = ReplyMessage.MESSAGE_DELETE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                }
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
            }

            return response;
        }
    }
}