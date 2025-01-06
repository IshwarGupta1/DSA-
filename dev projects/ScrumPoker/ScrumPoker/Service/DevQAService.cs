using Microsoft.EntityFrameworkCore;
using ScrumPoker.Models;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace ScrumPoker.Service
{
    public class DevQAService : IDevQAService
    {
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IHubContext<GameHub> _hubContext;
        private readonly List<int> points = new List<int> { 1, 2, 3, 5, 8, 13, 21 };

        public DevQAService(DataContext dataContext, IHttpContextAccessor contextAccessor, IHubContext<GameHub> hubContext)
        {
            _dataContext = dataContext;
            _contextAccessor = contextAccessor;
            _hubContext = hubContext;
        }

        public async Task<Vote> CastVoteAsync(string gameCode, Vote vote, int userId)
        {
            var game = await _dataContext.Game.FirstOrDefaultAsync(g => g.gameCode == gameCode);
            if (game == null || !game.isVotingOpen)
            {
                throw new InvalidOperationException("Game not found or voting is closed.");
            }

            if (!points.Contains(vote.storyPoints))
            {
                throw new InvalidOperationException("points given must be a Fibonacci number.");
            }

            var voter = await _dataContext.Users.FirstOrDefaultAsync(user => user.userId == userId);
            var existingVote = game.votes.FirstOrDefault(v => v.playerId == userId);
            if (existingVote != null)
            {
                existingVote.storyPoints = vote.storyPoints;
                existingVote.role = voter!.userRole;
            }
            else
            {
                vote.playerId = userId;
                vote.role = voter!.userRole;
                game.votes.Add(vote);
            }

            try
            {
                await _dataContext.AddAsync(vote);
                await _dataContext.SaveChangesAsync();
                await _hubContext.Clients.Group(gameCode).SendAsync("VoteCast", gameCode, vote);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new InvalidOperationException("A concurrency conflict occurred. Please try again.");
            }

            return vote;
        }

        public async Task<double> GetDevVoteAsync(string gameCode)
        {
            var game = await _dataContext.Game.Include(g => g.votes).FirstOrDefaultAsync(g => g.gameCode == gameCode);
            if (game == null || !game.isVotingOpen)
            {
                throw new InvalidOperationException("Game not found or voting is closed.");
            }
            var devPoints = game.votes.Where(g => g.role == Role.Dev).ToList();
            if (devPoints.Count == 0)
            {
                throw new InvalidOperationException("No dev votes found.");
            }
            var averagePoints = devPoints.Average(v => v.storyPoints);

            return averagePoints;
        }

        public async Task<double> GetQAVoteAsync(string gameCode)
        {
            var game = await _dataContext.Game.Include(g => g.votes).FirstOrDefaultAsync(g => g.gameCode == gameCode);
            if (game == null || !game.isVotingOpen)
            {
                throw new InvalidOperationException("Game not found or voting is closed.");
            }

            // Get the QA votes for the game
            var qaVotes = game.votes.Where(g => g.role == Role.QA).ToList();

            if (qaVotes.Count == 0)
            {
                throw new InvalidOperationException("No QA votes found.");
            }

            // Calculate the average of the QA votes
            var averagePoints = qaVotes.Average(v => v.storyPoints);

            return averagePoints;
        }

        public async Task<Game> JoinGameAsync(string gameCode, int userId)
        {
            var game = await _dataContext.Game.FirstOrDefaultAsync(g => g.gameCode == gameCode);
            if (game == null)
            {
                throw new Exception("Game not found.");
            }

            var existingPlayer = game.votes.FirstOrDefault(v => v.playerId == userId);
            if (existingPlayer != null)
            {
                throw new InvalidOperationException("User has already joined this game.");
            }

            var userRole = _contextAccessor.HttpContext!.User.FindFirst(ClaimTypes.Role)?.Value;

            var vote = new Vote
            {
                playerId = userId,
                role = roleOfUser(userRole!)
            };
            game.votes.Add(vote);
            await _dataContext.SaveChangesAsync();

            await _hubContext.Clients.Group(gameCode).SendAsync("PlayerJoined", gameCode, vote);

            return game;
        }

        private Role roleOfUser(string role)
        {
            switch (role)
            {
                case "QA":
                    return Role.QA;
                case "Dev":
                    return Role.Dev;
                case "ScrumMaster":
                    return Role.ScrumMaster;
                default:
                    throw new Exception("invalid role");
            }
        }
    }
}
