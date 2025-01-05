using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Models;
using TicketBooking.Service;

namespace TicketBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;

        public AuthController(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            // Check if the username already exists
            var user = await _context.user.FirstOrDefaultAsync(u => u.userName == request.Username);
            if (user != null)
            {
                return BadRequest(new { message = "Username already exists" });
            }

            // Create a new user
            user = new User
            {
                userName = request.Username,
                passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = request.Role,
            };

            _context.user.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully" });
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // Find the user by username
            var user = await _context.user.SingleOrDefaultAsync(u => u.userName == request.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.passwordHash))
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            // Generate JWT token
            var token = _authService.GenerateJwtToken(user.userName, user.Role);
            return Ok(new { token });
        }
    }
}
