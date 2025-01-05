using NUnit.Framework;
using ScrumPoker.Models;
using ScrumPoker.Service;
using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using ScrumPoker;

[TestFixture]
public class ScrumMasterServiceTests
{
    private ScrumMasterService _service;
    private DataContext _mockDataContext;
    private IHttpContextAccessor _mockHttpContextAccessor;
    private GameHub _gameHub;

    [SetUp]
    public void Setup()
    {
        _mockDataContext = Substitute.For<DataContext>();
        _mockHttpContextAccessor = Substitute.For<IHttpContextAccessor>();
        _gameHub = Substitute.For<GameHub>();
        _service = new ScrumMasterService(_mockDataContext, _mockHttpContextAccessor, (Microsoft.AspNetCore.SignalR.IHubContext<GameHub>)_gameHub);
    }

    [Test]
    public async Task CreateGameAsync_ShouldThrowUnauthorizedAccessException_WhenUserIsNotScrumMaster()
    {
        // Arrange
        SetUserRole("Dev");

        // Act & Assert
        var ex = Assert.ThrowsAsync<UnauthorizedAccessException>(async () => await _service.createGameAsync());
        Assert.Equals("only scrum master can create a game", ex.Message);
    }

    [Test]
    public async Task CreateGameAsync_ShouldCreateGame_WhenUserIsScrumMaster()
    {
        // Arrange
        SetUserRole("ScrumMaster");
        var mockGamesDbSet = Substitute.For<DbSet<Game>>();
        _mockDataContext.Game.Returns(mockGamesDbSet);

        // Act
        var result = await _service.createGameAsync();

        // Assert
        Assert.Equals(6, result.gameCode.Length);
        Assert.Equals(result.isVotingOpen, true);
        await _mockDataContext.Game.Received(1).AddAsync(Arg.Any<Game>());
        await _mockDataContext.Received(1).SaveChangesAsync();
    }

    [Test]
    public async Task RevealVotesAsync_ShouldThrowUnauthorizedAccessException_WhenUserIsNotScrumMaster()
    {
        // Arrange
        SetUserRole("Dev");
        string gameCode = "testGameCode";

        // Act & Assert
        var ex = Assert.ThrowsAsync<UnauthorizedAccessException>(async () => await _service.revealVotesAsync(gameCode, 1));
        Assert.Equals("only scrum master can reveal votes", ex.Message);
    }

    [Test]
    public async Task RevealVotesAsync_ShouldThrowException_WhenGameDoesNotExist()
    {
        // Arrange
        SetUserRole("ScrumMaster");
        string gameCode = "nonExistentGameCode";
        _mockDataContext.Game.FirstOrDefault(Arg.Any<Func<Game, bool>>()).Returns((Game)null);

        // Act & Assert
        var ex = Assert.ThrowsAsync<Exception>(async () => await _service.revealVotesAsync(gameCode, 1));
        Assert.Equals("game does not exist", ex.Message);
    }

    [Test]
    public async Task RevealVotesAsync_ShouldReturnVotes_WhenGameExistsAndUserIsScrumMaster()
    {
        // Arrange
        SetUserRole("ScrumMaster");
        string gameCode = "testGameCode";
        var mockGame = new Game
        {
            gameCode = gameCode,
            isVotingOpen = true,
            votes = new List<Vote> { new Vote { playerId = 1, storyPoints = 5, role = Role.Dev } }
        };

        _mockDataContext.Game.FirstOrDefault(Arg.Any<Func<Game, bool>>()).Returns(mockGame);

        // Act
        var result = await _service.revealVotesAsync(gameCode, 1);

        // Assert
        Assert.Equals(1, result.Count());
        Assert.Equals(5, result.First().storyPoints);
        Assert.Equals(mockGame.isVotingOpen, false);
        await _mockDataContext.Received(1).SaveChangesAsync();
    }

    private void SetUserRole(string role)
    {
        var claims = new List<Claim> { new Claim(ClaimTypes.Role, role) };
        var identity = new ClaimsIdentity(claims, "TestAuthType");
        var claimsPrincipal = new ClaimsPrincipal(identity);
        _mockHttpContextAccessor.HttpContext.Returns(new DefaultHttpContext { User = claimsPrincipal });
    }
}
