using Microsoft.AspNetCore.Mvc;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.Services;
using E_Project_3_API.Services.Interfaces;

namespace E_Project_3_API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ShowtimesController : ControllerBase
    {
        private readonly IShowtimeServices _showtimeService;

        public ShowtimesController(IShowtimeServices showtimeService)
        {
            _showtimeService = showtimeService;
        }

        [HttpGet]
        public IActionResult GetAllShowtimes()
        {
            var showtimes = _showtimeService.GetAllShowtimes();
            return Ok(showtimes);
        }

        [HttpGet("{id}")]
        public IActionResult GetShowtime(int id)
        {
            var showtime = _showtimeService.GetShowtime(id);
            if (showtime == null)
            {
                return NotFound(new
                {
                    isGet = false,
                    message = "Not Found"
                });
            }
            return Ok(showtime);
        }

        [HttpPost]
        public IActionResult CreateShowtime(ShowtimeRequest request)
        {
            var response = _showtimeService.CreateShowtime(request);
            return Ok(response);
        }

        //[HttpPut("{id}")]
        //public IActionResult UpdateShowtime(int id, ShowtimeRequest request)
        //{
        //    var response = _showtimeService.UpdateShowtime(id, request);
        //    if (!response.IsModified)
        //    {
        //        return BadRequest(response.Error);
        //    }
        //    return Ok();
        //}

        [HttpDelete("{id}")]
        public IActionResult DeleteShowtime(int id)
        {
            var response = _showtimeService.DeleteShowtime(id);
            return Ok(response);
        }
    }
}
