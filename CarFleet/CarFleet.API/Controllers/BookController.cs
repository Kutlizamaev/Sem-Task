using CarFleet.BLL.DTO;
using CarFleet.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarFleet.API.Controllers
{
    [Authorize]
    [Route("api/booking/")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly OrdersService _ordersService;
        public BookController(OrdersService bookingService)
        {
            _ordersService = bookingService;
        }

        //GET: api/booking/close
        [HttpGet("close")]
        public async Task<IActionResult> CloseOrder(string id)
        {
            if (id == null)
            {
                return BadRequest("Order is not found");
            }

            await _ordersService.CloseOrder(id);
            return Ok();
        }

        //POST: api/booking/book
        [HttpPost("book")]
        public async Task<IActionResult> Booking([FromForm] BookingOrderDTO dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Data is invalid");
            }

            string id = await _ordersService.Book(dto);

            return Ok(id);
        }

        
    }
}
