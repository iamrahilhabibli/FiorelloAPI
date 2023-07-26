using Fiorello.Application.Abstraction.Services;
using Fiorello.Application.DTOs.ResponseDTOs;
using Fiorello.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Fiorello.Persistence.Implementations.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenResponseDto CreateJwtToken(AppUser appUser)
        {
            DateTime expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:EXPIRATION_MINUTES"]));
            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,appUser.Id.ToString()),
                // subject user id
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                // new JWT ID
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                // date time token generated
                new Claim(ClaimTypes.NameIdentifier,appUser.Email.ToString()),
                // Unique name identifier of the user (email)
            };
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken tokenGenerator = new JwtSecurityToken(
                _configuration["Jwt:issuer"],
                _configuration["Jwt:audience"],
                claims,
                expires: expiration,
                signingCredentials: signingCredentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string token = handler.WriteToken(tokenGenerator);
            string refreshToken = GenerateRefeshToken();

            //add expiration 
            DateTime refreshTokenExpiration = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["RefreshToken:EXPIRATION_MINUTES"]));
            return new TokenResponseDto(token, expiration, refreshTokenExpiration, refreshToken);
        }
        private string GenerateRefeshToken()
        {
            byte[] bytes = new byte[64];
            var randomNumber = RandomNumberGenerator.Create();
            randomNumber.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
