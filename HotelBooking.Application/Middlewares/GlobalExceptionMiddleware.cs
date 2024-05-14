using HotelBooking.Domain.DTOs.Response.Common;
using HotelBooking.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Application.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public GlobalExceptionMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ với mã lỗi HTTP đã chỉ định
                string message = ex.Message;
                string? code = null;
                List<string> errors = new();

                if (ex is AppException appException)
                {
                    code = appException.Code;
                    message = appException.Message;
                    errors = appException.Errors;
                }

                var result = new ObjectResult(new CommonErrorResponse
                {
                    Message = message,
                    Code = code,
                    StackTrace = _env.EnvironmentName == "Development" ? ex.StackTrace : null,
                    Errors = errors
                })
                {
                    StatusCode = ex is AppException httpException
                        ? (int)httpException.StatusCode
                        : 500,
                };

                context.Response.StatusCode = result.StatusCode.Value;
                await context.Response.WriteAsJsonAsync(result.Value);
            }
        }
    }
}
