using JDPodrozeAPI.Core.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace JDPodrozeAPI.Core.Services.JWT
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;

        private readonly TimeSpan TokenLifeTime = TimeSpan.FromHours(8);

        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> CreateToken(UserDTO user)
        {
            byte[] key = Encoding.UTF8.GetBytes(_configuration["Authentication:SigningKey"]!);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Expires = DateTime.UtcNow.Add(TokenLifeTime),
                Issuer = _configuration["Authentication:Issuer"],
                Audience = _configuration["Authentication:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new("Id", user.Id.ToString()),
                        new("Login", user.Login),
                        new("Email", user.Email),
                        new(ClaimTypes.Role, user.IsAdmin ? "ADMINISTRATOR" : "USER")
                    }
                )
            };

            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            string jsonWebToken = await Task.Run(() => tokenHandler.WriteToken(token));
            return jsonWebToken;
        }
    }
}