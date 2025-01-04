using ScrumPoker.Models;

public interface IDevQAService
{
    Task<Game> JoinGameAsync(string gameCode, int userId);
    Task<Vote> CastVoteAsync(string gameCode, Vote vote, int userId);
    Task<int> GetDevVoteAsync(string gameCode);
    Task<int> GetQAVoteAsync(string gameCode);
}
