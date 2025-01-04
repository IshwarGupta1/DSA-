using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScrumPoker;
using ScrumPoker.Models;
using ScrumPoker.Service;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly DataContext _context;
    private readonly AuthService _authService;

    public AuthController(DataContext context, AuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    // POST: api/auth/register
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        // Check if the username already exists
        if (await _context.Users.AnyAsync(u => u.userName == request.Username))
        {
            return BadRequest(new { message = "Username already exists" });
        }

        if (!Enum.TryParse<Role>(request.Role.ToString(), true, out var role))
        {
            return BadRequest(new { message = "Invalid role specified" });
        }


        // Create a new user
        var user = new User
        {
            userName = request.Username,
            passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            userRole = role // Role can be Dev, QA, Scrum Master
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(new { message = "User registered successfully" });
    }

    // POST: api/auth/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        // Find the user by username
        var user = await _context.Users.SingleOrDefaultAsync(u => u.userName == request.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.passwordHash))
        {
            return Unauthorized(new { message = "Invalid username or password" });
        }

        // Generate JWT token
        var token = _authService.GenerateJwtToken(user.userName, user.userRole.ToString());
        return Ok(new { token });
    }
}
