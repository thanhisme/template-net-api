using HotelBooking.Domain.IServices;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HotelBooking.Services.Services
{
    public class HttpContextService : IHttpContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? CurrentUserId
        {
            get
            {
                HttpContext? httpContext = _httpContextAccessor.HttpContext;

                if (httpContext != null)
                {
                    Claim? nameIdentifier = httpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                    if (nameIdentifier != null)
                    {
                        return Convert.ToInt16(nameIdentifier.Value);
                    }
                }

                return null;
            }
        }

        public ClaimsPrincipal? CurrentUser
        {
            get
            {
                HttpContext? httpContext = _httpContextAccessor.HttpContext;

                return httpContext?.User;
            }

        }

        public string? CurrentUserRole
        {
            get
            {
                HttpContext? httpContext = _httpContextAccessor.HttpContext;

                if (httpContext != null)
                {
                    Claim? role = httpContext.User.FindFirst(ClaimTypes.Role);
                    if (role != null)
                    {
                        return role.Value;
                    }
                }

                return null;
            }
        }
    }
}
