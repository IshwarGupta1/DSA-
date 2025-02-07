using ATM.Models;
public class Session
{
    public string SessionId { get; private set; }
    public ATM.Models.User User { get; private set; }
    private long _lastActivityTimestamp;
    private static readonly long SessionTimeout = 300000;

    public Session(ATM.Models.User user)
    {
        SessionId = Guid.NewGuid().ToString();
        User = user;
        _lastActivityTimestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }

    // Check if the session has timed out
    public bool IsSessionTimedOut()
    {
        long currentTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        return (currentTime - _lastActivityTimestamp) > SessionTimeout;
    }

    // Update the last activity timestamp
    public void UpdateLastActivity()
    {
        _lastActivityTimestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }
}
