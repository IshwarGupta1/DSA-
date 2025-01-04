using Microsoft.AspNetCore.Mvc;
using ScrumPoker.Models;
using ScrumPoker.Service;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ScrumPoker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrumMasterController : ControllerBase
    {
        private readonly IScrumMasterService _scrumMasterService;

        public ScrumMasterController(IScrumMasterService scrumMasterService)
        {
            _scrumMasterService = scrumMasterService;
        }

        /// <summary>
        /// Creates a new game.
        /// Only ScrumMaster can create a game.
        /// </summary>
        [HttpPost("create")]
        [ProducesResponseType(typeof(Game), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> CreateGameAsync()
        {
            try
            {
                var game = await _scrumMasterService.createGameAsync();
                return CreatedAtAction(nameof(CreateGameAsync), new { gameCode = game.gameCode }, game);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Reveals the votes for a game.
        /// Only ScrumMaster can reveal votes.
        /// </summary>
        [HttpPost("{gameCode}/reveal")]
        [ProducesResponseType(typeof(IEnumerable<Vote>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> RevealVotesAsync(string gameCode)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
                var votes = await _scrumMasterService.revealVotesAsync(gameCode, userId);
                return Ok(votes);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
