using NUnit.Framework;
using NSubstitute;
using Microsoft.EntityFrameworkCore;
using ScrumPoker.Models;
using ScrumPoker.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ScrumPoker.Tests
{
    public class DevQAServiceTests
    {
        private DevQAService _service;
        private DataContext _mockDataContext;
        private IHttpContextAccessor _mockContextAccessor;
        private GameHub _gameHub;

        [SetUp]
        public void SetUp()
        {
            // Create mocks for dependencies
            _mockDataContext = Substitute.For<DataContext>();
            _mockContextAccessor = Substitute.For<IHttpContextAccessor>();
            _gameHub = Substitute.For<GameHub>();

            // Initialize the service with the mocked dependencies
            _service = new DevQAService(_mockDataContext, _mockContextAccessor, (Microsoft.AspNetCore.SignalR.IHubContext<GameHub>)_gameHub);
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
            Assert.Equals("Game not found or voting is closed.", ex.Message);
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
            Assert.Equals("points given must be a Fibonacci number.", ex.Message);
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
            Assert.Equals(userId, result.playerId);
            Assert.Equals(Role.Dev, result.role);
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
            Assert.Equals("No dev votes found.", ex.Message);
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
            Assert.Equals(6.5, result);
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
            Assert.Equals("Game not found.", ex.Message);
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
            Assert.Equals("User has already joined this game.", ex.Message);
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
            Assert.Equals(Role.Dev, addedVote!.role);
            Assert.Equals(userId, addedVote.playerId);
        }
    }
}
