using NUnit.Framework;
using ScrumPoker.Service;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

[TestFixture]
public class AuthServiceTests
{
    private AuthService _authService;
    private const string JwtKey = "ThisIsASecretKey12345";
    private const string Issuer = "TestIssuer";
    private const string Audience = "TestAudience";

    [SetUp]
    public void Setup()
    {
        _authService = new AuthService(JwtKey, Issuer, Audience);
    }

    [Test]
    public void GenerateJwtToken_ShouldReturnValidToken_WhenCalledWithValidInputs()
    {
        // Arrange
        string userId = "1";
        string username = "testuser";
        string role = "ScrumMaster";

        // Act
        var token = _authService.GenerateJwtToken(userId, username, role);

        // Assert
        var handler = new JwtSecurityTokenHandler();
        Assert.That(handler.CanReadToken(token), Is.True, "Generated token is not readable.");

        // Validate the token
        var key = Encoding.UTF8.GetBytes(JwtKey);
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Issuer,
            ValidAudience = Audience,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };

        handler.ValidateToken(token, validationParameters, out var validatedToken);
        Assert.That(validatedToken, Is.Not.Null, "Validated token should not be null.");

        var jwtToken = (JwtSecurityToken)validatedToken;

        // Assert claims
        Assert.That(jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value, Is.EqualTo(userId));
        Assert.That(jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value, Is.EqualTo(username));
        Assert.That(jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value, Is.EqualTo(role));
    }

    [Test]
    public void GenerateJwtToken_ShouldThrowException_WhenKeyIsInvalid()
    {
        // Arrange
        var invalidAuthService = new AuthService("InvalidKey", Issuer, Audience);
        string userId = "1";
        string username = "testuser";
        string role = "ScrumMaster";

        // Act
        var token = invalidAuthService.GenerateJwtToken(userId, username, role);

        var handler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(JwtKey);

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Issuer,
            ValidAudience = Audience,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };

        // Assert
        Assert.Throws<SecurityTokenInvalidSignatureException>(() =>
        {
            handler.ValidateToken(token, validationParameters, out _);
        });
    }
}
