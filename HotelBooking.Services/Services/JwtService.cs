using HotelBooking.Domain;
using HotelBooking.Domain.IServices;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelBooking.Services.Services
{
    public class JwtService : IJwtService
    {
        private readonly AppSettingConfiguration _appConfig;

        public JwtService(AppSettingConfiguration appConfig)
        {
            _appConfig = appConfig;
        }

        public string GenerateSecurityToken(List<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfig.Jwt.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();
            string jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
