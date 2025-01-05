using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Models;
using TicketBooking.Service;

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminOnly")]
    public class EventController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public EventController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] Event newEvent)
        {
            var createdEvent = await _adminService.CreateEvent(newEvent);
            return CreatedAtAction(nameof(GetEventById), new { eventId = createdEvent.Id }, createdEvent);
        }

        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetEventById(int eventId)
        {
            var eventEntity = await _adminService.GetEventById(eventId);
            return Ok(eventEntity);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _adminService.GetAllEvents();
            return Ok(events);
        }

        [HttpPut("{eventId}")]
        public async Task<IActionResult> UpdateEvent(int eventId, [FromBody] Event updatedEvent)
        {
            var eventEntity = await _adminService.UpdateEvent(eventId, updatedEvent);
            return Ok(eventEntity);
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            await _adminService.DeleteEvent(eventId);
            return NoContent();
        }
    }
}
