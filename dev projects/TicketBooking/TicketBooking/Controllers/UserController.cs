using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Models;
using TicketBooking.Service;

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "UserOnly")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("available-events")]
        public async Task<IActionResult> GetAvailableEvents()
        {
            var availableEvents = await _userService.GetAvailableEvents();
            return Ok(availableEvents);
        }

        [HttpGet("/allBookings")]
        public async Task<IActionResult> getAllBookings([FromBody] int userId)
        {
            var bookings = await _userService.listAllBookings(userId);
            return Ok(new {bookings = bookings});
        }

        [HttpGet("/availability/{eventId}/{seatId}")]
        public async Task<IActionResult> getAvailability(int seatId, int eventId)
        {
            var availability = await _userService.IsSeatAvailableForEvent(seatId, eventId);
            return Ok(new { SeatId = seatId, IsAvailable = availability });
        }

        [HttpPost("/seatbooking/{eventId}")]
        public async Task<IActionResult> seatBookingbyEvent(int eventId, [FromBody] int userId)
        {
            var bookingResponse = await _userService.bookSeat(eventId, userId);
            return Ok(new { Message = "Seat booked successfully.", BookingResp = bookingResponse });
        }

        [HttpPost("/seatbooking/{eventId}/{category}")]
        public async Task<IActionResult> seatBookingbyEvent(int eventId, int category, [FromBody] int userId)
        {
            var bookingResponse = await _userService.bookSeatByCategory(eventId, userId, (SeatType)category);
            return Ok(new { Message = "Seat booked successfully.", BookingResp = bookingResponse });
        }

        [HttpPut("/cancel/{bookingId}")]
        public async Task<IActionResult> cancelBooking(int eventId, [FromBody] int userId)
        {
            await _userService.CancelBooking(eventId, userId);
            return Ok(new { Message = "Booking Cancelled." });
        }
    }
}
