using Microsoft.AspNetCore.Mvc;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.Services;
using E_Project_3_API.Services.Interfaces;

namespace E_Project_3_API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatServices _seatService;

        public SeatsController(ISeatServices seatService)
        {
            _seatService = seatService;
        }

        [HttpGet]
        public IActionResult GetAllSeats()
        {
            var seats = _seatService.GetAllSeats();
            return Ok(seats);
        }

        [HttpGet("{id}")]
        public IActionResult GetSeatById(int id)
        {
            var seat = _seatService.GetSeat(id);
            if (seat == null)
            {
                return NotFound(new
                {
                    isGet = false,
                    message = "Not Found"
                });
            }
            return Ok(seat);
        }

        [HttpPost]
        public IActionResult CreateSeat(SeatRequest request)
        {
            var response = _seatService.CreateSeat(request);
            
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSeat(int id, SeatRequest request)
        {
            var response = _seatService.UpdateSeat(id, request);
           
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSeat(int id)
        {
            var response = _seatService.DeleteSeat(id);
             return Ok(response);
        }
    }
}
