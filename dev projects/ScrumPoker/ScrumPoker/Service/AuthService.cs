using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ScrumPoker.Service
{
    public class AuthService
    {
        private readonly string _jwtKey;
        private readonly string _issuer;
        private readonly string _audience;

        public AuthService(string jwtKey, string issuer, string audience)
        {
            _jwtKey = jwtKey;
            _issuer = issuer;
            _audience = audience;
        }

        public string GenerateJwtToken(string userId, string username, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtKey); // Use UTF-8 encoding for key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
               {
                    new Claim(ClaimTypes.NameIdentifier, userId), // Add the unique identifier
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }),
                IssuedAt = DateTime.UtcNow,
                Issuer = _issuer,
                Audience = _audience,
                Expires = DateTime.UtcNow.AddMinutes(30), // can change exprires time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
