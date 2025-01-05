using NUnit.Framework;
using NSubstitute;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TicketBooking.Service;

namespace TicketBooking.Tests
{
    [TestFixture]
    public class AuthServiceTests
    {
        private const string JwtKey = "test_secret_key_1234567890";
        private const string Issuer = "TestIssuer";
        private const string Audience = "TestAudience";

        private AuthService _authService;

        [SetUp]
        public void SetUp()
        {
            _authService = new AuthService(JwtKey, Issuer, Audience);
        }

        [Test]
        public void GenerateJwtToken_ValidInputs_ReturnsValidToken()
        {
            // Arrange
            var username = "testuser";
            var role = "admin";

            // Act
            var token = _authService.GenerateJwtToken(username, role);

            // Assert

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(JwtKey);
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Issuer,
                ValidAudience = Audience,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

            Assert.Equals(username, principal.Identity.Name);
        }

        [Test]
        public void GenerateJwtToken_EmptyUsername_ThrowsArgumentException()
        {
            // Arrange
            var username = string.Empty;
            var role = "admin";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _authService.GenerateJwtToken(username, role));
            Assert.Equals("Username cannot be empty.", ex.Message);
        }

        [Test]
        public void GenerateJwtToken_EmptyRole_ThrowsArgumentException()
        {
            // Arrange
            var username = "testuser";
            var role = string.Empty;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _authService.GenerateJwtToken(username, role));
            Assert.Equals("Role cannot be empty.", ex.Message);
        }
    }
}
