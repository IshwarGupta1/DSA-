using Microsoft.EntityFrameworkCore;
using ScrumPoker.Models;
using System.Security.Claims;

namespace ScrumPoker.Service
{
    public class DevQAService : IDevQAService
    {
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly List<int> points = new List<int> { 1, 2, 3 , 5, 8, 13, 21};
        public DevQAService(DataContext dataContext, IHttpContextAccessor contextAccessor)
        {
            _dataContext = dataContext;
            _contextAccessor = contextAccessor;
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

            await _dataContext.SaveChangesAsync();
            return vote;
        }

        public async Task<int> GetDevVoteAsync(string gameCode)
        {
            var game = await _dataContext.Game.FirstOrDefaultAsync(g => g.gameCode == gameCode);
            if (game == null || !game.isVotingOpen)
            {
                throw new InvalidOperationException("Game not found or voting is closed.");
            }
            var devPoints = game.votes.Where(g => g.role == Role.Dev).Sum(v => v.storyPoints);
            return devPoints;
        }

        public async Task<int> GetQAVoteAsync(string gameCode)
        {
            var game = await _dataContext.Game.FirstOrDefaultAsync(g => g.gameCode == gameCode);
            if (game == null || !game.isVotingOpen)
            {
                throw new InvalidOperationException("Game not found or voting is closed.");
            }
            var qaPoints = game.votes.Where(g => g.role == Role.QA).Sum(v => v.storyPoints);
            return qaPoints;
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
