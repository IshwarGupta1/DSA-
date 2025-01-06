using NUnit.Framework;
using NSubstitute;
using System;
using System.Linq;
using System.Threading.Tasks;
using ScrumPoker.Service;
using ScrumPoker.Models;
using System.Security.Claims;
using ScrumPoker.Service;
using Microsoft.AspNetCore.SignalR;

namespace ScrumPoker.Tests
{
    [TestFixture]
    public class DevQAServiceTests
    {
        private IDevQAService _service;
        private DataContext _mockDataContext;
        private IHttpContextAccessor _mockContextAccessor;
        private IHubContext<GameHub> _mockHubContext;

        [SetUp]
        public void Setup()
        {
            // Setup your mocks here
            _mockDataContext = Substitute.For<DataContext>();
            _mockContextAccessor = Substitute.For<IHttpContextAccessor>();
            _service = new DevQAService(_mockDataContext, _mockContextAccessor, _mockHubContext);
        }

        [Test]
        public async Task CastVoteAsync_GameNotFound_ThrowsInvalidOperationException()
        {
            // Arrange
            string gameCode = "Game123";
            var vote = new Vote { storyPoints = 5 };
            int userId = 1;

            _mockDataContext.Game.FirstOrDefault(Arg.Any<Func<Game, bool>>()).Returns((Game)null);

            // Act & Assert
            var ex = Assert.ThrowsAsync<InvalidOperationException>(() => _service.CastVoteAsync(gameCode, vote, userId));
            Assert.That(ex.Message, Is.EqualTo("Game not found or voting is closed."));
        }

        [Test]
        public async Task CastVoteAsync_InvalidPoints_ThrowsInvalidOperationException()
        {
            // Arrange
            string gameCode = "Game123";
            var vote = new Vote { storyPoints = 4 };  // Invalid point (not a Fibonacci number)
            int userId = 1;

            var game = new Game { gameCode = gameCode, isVotingOpen = true, votes = new List<Vote>() };
            _mockDataContext.Game.FirstOrDefault(Arg.Any<Func<Game, bool>>()).Returns(game);

            // Act & Assert
            var ex = Assert.ThrowsAsync<InvalidOperationException>(() => _service.CastVoteAsync(gameCode, vote, userId));
            Assert.That(ex.Message, Is.EqualTo("points given must be a Fibonacci number."));
        }

        [Test]
        public async Task CastVoteAsync_ValidVote_CastsVoteSuccessfully()
        {
            // Arrange
            string gameCode = "Game123";
            var vote = new Vote { storyPoints = 5 };
            int userId = 1;
            var user = new User { userId = userId, userRole = Role.Dev };

            var game = new Game { gameCode = gameCode, isVotingOpen = true, votes = new List<Vote>() };
            _mockDataContext.Game.FirstOrDefault(Arg.Any<Func<Game, bool>>()).Returns(game);
            _mockDataContext.Users.FirstOrDefault(Arg.Any<Func<User, bool>>()).Returns(user);

            _mockContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Returns(new Claim(ClaimTypes.Role, "Dev"));

            // Act
            var result = await _service.CastVoteAsync(gameCode, vote, userId);

            // Assert
            Assert.That(result.playerId, Is.EqualTo(userId));
            Assert.That(result.role, Is.EqualTo(Role.Dev));
        }

        [Test]
        public async Task GetDevVoteAsync_NoVotes_ThrowsInvalidOperationException()
        {
            // Arrange
            string gameCode = "Game123";
            var game = new Game { gameCode = gameCode, isVotingOpen = true, votes = new List<Vote>() };
            _mockDataContext.Game.FirstOrDefault(Arg.Any<Func<Game, bool>>()).Returns(game);

            // Act & Assert
            var ex = Assert.ThrowsAsync<InvalidOperationException>(() => _service.GetDevVoteAsync(gameCode));
            Assert.That(ex.Message, Is.EqualTo("No dev votes found."));
        }

        [Test]
        public async Task GetDevVoteAsync_ValidVotes_ReturnsAverage()
        {
            // Arrange
            string gameCode = "Game123";
            var game = new Game
            {
                gameCode = gameCode,
                isVotingOpen = true,
                votes = new List<Vote>
                {
                    new Vote { storyPoints = 5, role = Role.Dev },
                    new Vote { storyPoints = 8, role = Role.Dev }
                }
            };
            _mockDataContext.Game.FirstOrDefault(Arg.Any<Func<Game, bool>>()).Returns(game);

            // Act
            var result = await _service.GetDevVoteAsync(gameCode);

            // Assert
            Assert.That(result, Is.EqualTo(6.5));
        }

        [Test]
        public async Task JoinGameAsync_GameNotFound_ThrowsException()
        {
            // Arrange
            string gameCode = "Game123";
            int userId = 1;

            _mockDataContext.Game.FirstOrDefault(Arg.Any<Func<Game, bool>>()).Returns((Game)null);

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(() => _service.JoinGameAsync(gameCode, userId));
            Assert.That(ex.Message, Is.EqualTo("Game not found."));
        }

        [Test]
        public async Task JoinGameAsync_UserAlreadyJoined_ThrowsInvalidOperationException()
        {
            // Arrange
            string gameCode = "Game123";
            int userId = 1;

            var game = new Game { gameCode = gameCode, votes = new List<Vote> { new Vote { playerId = userId } } };
            _mockDataContext.Game.FirstOrDefault(Arg.Any<Func<Game, bool>>()).Returns(game);

            // Act & Assert
            var ex = Assert.ThrowsAsync<InvalidOperationException>(() => _service.JoinGameAsync(gameCode, userId));
            Assert.That(ex.Message, Is.EqualTo("User has already joined this game."));
        }

        [Test]
        public async Task JoinGameAsync_ValidJoin_AddsUserToGame()
        {
            // Arrange
            string gameCode = "Game123";
            int userId = 1;
            var game = new Game { gameCode = gameCode, votes = new List<Vote>() };
            var user = new User { userId = userId, userRole = Role.Dev };

            _mockDataContext.Game.FirstOrDefault(Arg.Any<Func<Game, bool>>()).Returns(game);
            _mockDataContext.Users.FirstOrDefault(Arg.Any<Func<User, bool>>()).Returns(user);
            _mockContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Returns(new Claim(ClaimTypes.Role, "Dev"));

            // Act
            var result = await _service.JoinGameAsync(gameCode, userId);
            var addedVote = result.votes.FirstOrDefault(v => v.playerId == userId);

            // Assert
            Assert.That(addedVote.role, Is.EqualTo(Role.Dev));
            Assert.That(addedVote.playerId, Is.EqualTo(userId));
        }
    }
}
