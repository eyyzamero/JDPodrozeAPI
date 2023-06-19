using JDPodrozeAPI.Core.DTOs.Users;
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

        public string CreateToken(UserDTO user)
        {
            byte[] key = Encoding.UTF8.GetBytes(_configuration["Authentication:SigningKey"]!);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.Add(TokenLifeTime),
                Issuer = _configuration["Authentication:Issuer"],
                Audience = _configuration["Authentication:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim("Id", user.Id.ToString()),
                        new Claim("Login", user.Login),
                        new Claim("Email", user.Email),
                        new Claim(ClaimTypes.Role, user.IsAdmin ? "ADMINISTRATOR" : "USER")
                    }
                )
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            string jsonWebToken = tokenHandler.WriteToken(token);
            return jsonWebToken;
        }
    }
}