using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StockLink.Auth.Application.Commons.Bases;
using StockLink.Auth.Application.Dtos.Usuario.Request;
using StockLink.Auth.Application.Interfaces;
using StockLink.Auth.Domain.Entities;
using StockLink.Auth.Infrastructure.Persistences.Interfaces;
using StockLink.Auth.Utilities.Static;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace StockLink.Auth.Application.Services
{
    public class AuthApplication : IAuthApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthApplication(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<BaseResponse<string>> Login(TokenRequestDto requestDto)
        {
            var response = new BaseResponse<string>();
            try
            {
                var user = await _unitOfWork.Usuario.UserByUser(requestDto.Username!);

                if (user is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_TOKEN_ERROR;
                    return response;
                }

                if (BC.Verify(requestDto.Password, user.Pass))
                {
                    response.IsSuccess = true;
                    response.Data = GenerateToken(user);
                    response.Message = ReplyMessage.MESSAGE_TOKEN;
                    return response;
                }
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
            }

            return response;
        }

        private string GenerateToken(TbUsuario usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]!));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, usuario.Username!),
                new Claim(JwtRegisteredClaimNames.FamilyName, usuario.Username!),
                new Claim(JwtRegisteredClaimNames.GivenName, usuario.Username!),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:Expires"]!)),
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}