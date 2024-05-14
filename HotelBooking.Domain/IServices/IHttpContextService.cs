using System.Security.Claims;

namespace HotelBooking.Domain.IServices
{
    public interface IHttpContextService
    {
        int? CurrentUserId { get; }
        ClaimsPrincipal? CurrentUser { get; }
        string? CurrentUserRole { get; }
    }
}
