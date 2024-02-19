using StockLink.Softland.Application.UseCase.Commons.Bases;
using StockLink.Softland.Application.UseCase.Commons.Exceptions;
using StockLink.Softland.Utilities.Constants;
using System.Text.Json;

namespace StockLink.Softland.Api.Extensions.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ValidationException ex)
            {
                context.Response.ContentType = "application/json";
                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
                {
                    Message = GlobalMessage.MESSAGE_VALIDATE,
                    Errors = ex.Errors,
                });

            }
        }
    }
}