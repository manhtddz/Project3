using Microsoft.AspNetCore.Mvc;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Services.Interfaces;
using E_Project_3_API.Services;

namespace E_Project_3_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TheatersController : ControllerBase
    {
        private readonly ITheaterServices _theaterService;

        public TheatersController(ITheaterServices theaterService)
        {
            _theaterService = theaterService;
        }

        [HttpGet]
        public IActionResult GetAllTheaters()
        {
            var theaters = _theaterService.GetAllTheaters();
            return Ok(theaters);
        }

        [HttpGet("{id}")]
        public IActionResult GetTheaterById(int id)
        {
            var theater = _theaterService.GetTheater(id);
            if (theater == null)
            {
                return NotFound(new
                {
                    isGet = false,
                    message = "Not Found"
                });
            }
            return Ok(theater);
        }

        [HttpPost]
        public IActionResult CreateTheater(TheaterRequest request)
        {
            var result = _theaterService.CreateTheater(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTheater(int id, TheaterRequest request)
        {
            var result = _theaterService.UpdateTheater(id, request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTheater(int id)
        {
            var result = _theaterService.DeleteTheater(id);
            return Ok(result);
        }
        [HttpGet("{startIndex}/{limit}")]
        public IActionResult GetPagingTheaters(int startIndex, int limit)
        {
            var result = _theaterService.GetPagingTheaters(startIndex, limit);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetLengthOfTheaters()
        {
            var result = _theaterService.GetAllTheaters().Count();
            return Ok(result);
        }
    }
}
