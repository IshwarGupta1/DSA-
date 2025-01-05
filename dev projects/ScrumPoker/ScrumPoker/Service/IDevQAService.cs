using ScrumPoker.Models;

public interface IDevQAService
{
    Task<Game> JoinGameAsync(string gameCode, int userId);
    Task<Vote> CastVoteAsync(string gameCode, Vote vote, int userId);
    Task<double> GetDevVoteAsync(string gameCode);
    Task<double> GetQAVoteAsync(string gameCode);
}
