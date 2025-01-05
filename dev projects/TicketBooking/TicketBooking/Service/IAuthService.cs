namespace TicketBooking.Service
{
    public interface IAuthService
    {
        public string GenerateJwtToken(string username, string role);
    }
}
