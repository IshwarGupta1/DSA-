using ScrumPoker.Models;

namespace ScrumPoker.Service
{
    public interface IScrumMasterService
    {
        public Task<Game> createGameAsync();
        public Task<IEnumerable<Vote>> revealVotesAsync(string gameCode, int userId);
    }
}
