using Microsoft.AspNetCore.SignalR;
using ScrumPoker.Models;

public class GameHub : Hub
{
    public async Task SendVoteUpdate(string gameCode, Vote updatedVote)
    {
        await Clients.Group(gameCode).SendAsync("ReceiveVoteUpdate", updatedVote);
    }

    public async Task JoinGameGroup(string gameCode)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, gameCode);
    }

    public async Task LeaveGameGroup(string gameCode)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, gameCode);
    }
}
