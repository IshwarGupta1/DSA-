using ScrumPoker.Models;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace ScrumPoker.Service
{
    public class ScrumMasterService : IScrumMasterService
    {
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IHubContext<GameHub> _hubContext;

        public ScrumMasterService(DataContext dataContext, IHttpContextAccessor contextAccessor, IHubContext<GameHub> hubContext)
        {
            _dataContext = dataContext;
            _contextAccessor = contextAccessor;
            _hubContext = hubContext;
        }

        public async Task<Game> createGameAsync()
        {
            var userRole = _contextAccessor.HttpContext!.User.FindFirst(ClaimTypes.Role)?.Value;
            if (!userRole!.Equals("ScrumMaster"))
            {
                throw new UnauthorizedAccessException("only scrum master can create a game");
            }
            var game = new Game
            {
                gameCode = Guid.NewGuid().ToString("N").Substring(0, 6),
                isVotingOpen = true
            };
            await _dataContext.Game.AddAsync(game);
            await _dataContext.SaveChangesAsync();
            return game;
        }

        public async Task<IEnumerable<Vote>> revealVotesAsync(string gameCode, int userId)
        {
            var userRole = _contextAccessor.HttpContext!.User.FindFirst(ClaimTypes.Role)?.Value;
            if (!userRole!.Equals("ScrumMaster"))
            {
                throw new UnauthorizedAccessException("only scrum master can reveal votes");
            }

            var game = _dataContext.Game.Include(g => g.votes).FirstOrDefault(g => g.gameCode == gameCode);
            if (game == null)
            {
                throw new Exception("game does not exist");
            }
            game.isVotingOpen = false;
            await _dataContext.SaveChangesAsync();

            await _hubContext.Clients.Group(gameCode).SendAsync("VotesRevealed", gameCode, game.votes);

            return game.votes;
        }
    }
}
