using NUnit.Framework;
using ScrumPoker.Service;
using System.IdentityModel.Tokens.Jwt;

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
        string username = "testuser";
        string role = "ScrumMaster";

        // Act
        var token = _authService.GenerateJwtToken(username, role);

        // Assert
        var handler = new JwtSecurityTokenHandler();
        Assert.Equals(handler.CanReadToken(token), true);

        var jwtToken = handler.ReadJwtToken(token);
        Assert.Equals(username, jwtToken.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value);
        Assert.Equals(role, jwtToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value);
        Assert.Equals(Issuer, jwtToken.Issuer);
        Assert.Equals(Audience, jwtToken.Audiences.FirstOrDefault());
    }
}