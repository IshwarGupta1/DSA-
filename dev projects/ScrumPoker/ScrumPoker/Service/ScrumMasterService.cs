using ScrumPoker.Models;
using System.Security.Claims;

namespace ScrumPoker.Service
{
    public class ScrumMasterService : IScrumMasterService
    {
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _contextAccessor;
        public ScrumMasterService(DataContext dataContext, IHttpContextAccessor contextAccessor)
        {
            _dataContext = dataContext;
            _contextAccessor = contextAccessor;
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
            
            var game = _dataContext.Game.FirstOrDefault(g=>g.gameCode == gameCode);
            if(game == null)
            {
                throw new Exception("game does not exist");
            }
            game.isVotingOpen = false;
            await _dataContext.SaveChangesAsync();
            return game.votes;
        }
    }
}
