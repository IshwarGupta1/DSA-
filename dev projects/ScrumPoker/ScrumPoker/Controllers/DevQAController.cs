using Microsoft.AspNetCore.Authorization;
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
    public class DevQAController : ControllerBase
    {
        private readonly IDevQAService _devQAService;

        public DevQAController(IDevQAService devQAService)
        {
            _devQAService = devQAService;
        }

        /// <summary>
        /// Joins a player (Dev or QA) to a game.
        /// </summary>
        [HttpPost("{gameCode}/join")]
        [ProducesResponseType(typeof(Game), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> JoinGameAsync(string gameCode)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
                var game = await _devQAService.JoinGameAsync(gameCode, userId);
                return Ok(game);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Casts a vote for a game.
        /// Only Dev or QA users can cast votes.
        /// </summary>
        [Authorize]
        [HttpPost("{gameCode}/vote")]
        [ProducesResponseType(typeof(Vote), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CastVoteAsync(string gameCode, [FromBody] Vote vote)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
                var castedVote = await _devQAService.CastVoteAsync(gameCode, vote, userId);
                return Ok(castedVote);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the total vote points for Devs in a game.
        /// </summary>
        [HttpGet("{gameCode}/devvotes")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDevVoteAsync(string gameCode)
        {
            try
            {
                var devVotePoints = await _devQAService.GetDevVoteAsync(gameCode);
                return Ok(devVotePoints);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the total vote points for QA in a game.
        /// </summary>
        [HttpGet("{gameCode}/qavotes")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetQAVoteAsync(string gameCode)
        {
            try
            {
                var qaVotePoints = await _devQAService.GetQAVoteAsync(gameCode);
                return Ok(qaVotePoints);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
