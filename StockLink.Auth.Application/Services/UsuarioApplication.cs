using AutoMapper;
using StockLink.Auth.Application.Commons.Bases;
using StockLink.Auth.Application.Dtos.Usuario.Request;
using StockLink.Auth.Application.Dtos.Usuario.Response;
using StockLink.Auth.Application.Interfaces;
using StockLink.Auth.Domain.Entities;
using StockLink.Auth.Infrastructure.Commons.Bases.Request;
using StockLink.Auth.Infrastructure.Commons.Bases.Response;
using StockLink.Auth.Infrastructure.Persistences.Interfaces;
using StockLink.Auth.Utilities.Static;
using BC = BCrypt.Net.BCrypt;

namespace StockLink.Auth.Application.Services
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<BaseEntityResponse<UsuarioResponseDto>>> ListUsuarios(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<UsuarioResponseDto>>();
            try
            {
                var usuarios = await _unitOfWork.Usuario.ListUsuarios(filters);

                if (usuarios is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<BaseEntityResponse<UsuarioResponseDto>>(usuarios);
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

        public async Task<BaseResponse<UsuarioByIdResponseDto>> UsuarioById(int id)
        {
            var response = new BaseResponse<UsuarioByIdResponseDto>();

            try
            {
                var usuario = await _unitOfWork.Usuario.GetByIdAsync(id);

                if (usuario is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<UsuarioByIdResponseDto>(usuario);
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

        public async Task<BaseResponse<bool>> RegisterUsuario(UsuarioRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var account = _mapper.Map<TbUsuario>(requestDto);
                account.Pass = BC.HashPassword(account.Pass);

                response.Data = await _unitOfWork.Usuario.RegisterAsync(account);

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

        public async Task<BaseResponse<bool>> EditUsuario(int id, UsuarioRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var usuarioEdit = await UsuarioById(id);

                if (usuarioEdit.Data is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                var usuario = _mapper.Map<TbUsuario>(requestDto);
                usuario.Id = id;
                usuario.Pass = BC.HashPassword(usuario.Pass);

                response.Data = await _unitOfWork.Usuario.EditAsync(usuario);

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

        public async Task<BaseResponse<bool>> RemoveUsuario(int id)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var usuario = await UsuarioById(id);

                if (usuario.Data is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                response.Data = await _unitOfWork.Usuario.RemoveAsync(id);

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

        public async Task<BaseResponse<UsuarioByIdResponseDto>> UsuarioByUser(string user)
        {
            var response = new BaseResponse<UsuarioByIdResponseDto>();

            try
            {
                var usuario = await _unitOfWork.Usuario.UserByUser(user);

                if (usuario is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<UsuarioByIdResponseDto>(usuario);
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
    }
}