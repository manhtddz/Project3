using Microsoft.AspNetCore.Mvc;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Services.Interfaces;
using E_Project_3_API.Services;

namespace E_Project_3_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieServices _movieService;

        public MoviesController(IMovieServices movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = _movieService.GetAllMovies();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound(new
                {
                    isGet = false,
                    message = "Not Found"
                }); ;
            }
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult CreateMovie(MovieRequest movieRequest)
        {
            var result = _movieService.CreateMovie(movieRequest);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, MovieRequest movieRequest)
        {
            var result = _movieService.UpdateMovie(id, movieRequest);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var result = _movieService.DeleteMovie(id);
            return Ok(result);
        }

        [HttpGet("{startIndex}/{limit}")]
        public IActionResult GetPagingMovies(int startIndex, int limit)
        {
            var result = _movieService.GetPagingMovies(startIndex, limit);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetLengthOfMovies()
        {
            var result = _movieService.GetAllMovies().Count();
            return Ok(result);
        }
    }
}
