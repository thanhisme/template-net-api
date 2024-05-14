using System.Security.Claims;

namespace HotelBooking.Domain.IServices
{
    public interface IJwtService
    {
        string GenerateSecurityToken(List<Claim> claims);
    }
}