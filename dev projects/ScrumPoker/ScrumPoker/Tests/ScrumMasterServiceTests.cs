using NUnit.Framework;
using ScrumPoker.Models;
using ScrumPoker.Service;
using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;

namespace ScrumPoker.Tests
{
    [TestFixture]
    public class ScrumMasterServiceTests
    {
        private ScrumMasterService _service;
        private DataContext _mockDataContext;
        private IHttpContextAccessor _mockHttpContextAccessor;
        private IHubContext<GameHub> _mockHubContext;

        [SetUp]
        public void Setup()
        {
            _mockDataContext = Substitute.For<DataContext>();
            _mockHttpContextAccessor = Substitute.For<IHttpContextAccessor>();
            _mockHubContext = Substitute.For<IHubContext<GameHub>>();
            _service = new ScrumMasterService(_mockDataContext, _mockHttpContextAccessor, _mockHubContext);
        }

        [Test]
        public async Task CreateGameAsync_ShouldThrowUnauthorizedAccessException_WhenUserIsNotScrumMaster()
        {
            // Arrange
            SetUserRole("Dev");

            // Act & Assert
            var ex = Assert.ThrowsAsync<UnauthorizedAccessException>(async () => await _service.createGameAsync());
            Assert.That(ex.Message, Is.EqualTo("only scrum master can create a game"));
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
            Assert.That(result.gameCode.Length, Is.EqualTo(6));
            Assert.That(result.isVotingOpen, Is.True);
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
            Assert.That(ex.Message, Is.EqualTo("only scrum master can reveal votes"));
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
            Assert.That(ex.Message, Is.EqualTo("game does not exist"));
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
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().storyPoints, Is.EqualTo(5));
            Assert.That(mockGame.isVotingOpen, Is.False);
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
}
