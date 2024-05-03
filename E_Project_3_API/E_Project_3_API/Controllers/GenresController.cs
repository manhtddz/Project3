using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.Models;
using E_Project_3_API.Services.Interfaces;
using Azure.Core;
using E_Project_3_API.Services;

namespace E_Project_3_API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreServices _genreService;

        public GenresController(IGenreServices genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult GetAllGenres()
        {
            var result = _genreService.GetAllGenres();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreById(int id)
        {
            var result = _genreService.GetGenreById(id);
            if (result == null)
            {
                return NotFound(new
                {
                    isGet = false,
                    message = "Not Found"
                });
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateGenre(GenreRequest request)
        {
            var result = _genreService.CreateGenre(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, GenreRequest request)
        {
            var result = _genreService.UpdateGenre(id, request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            var result = _genreService.DeleteGenre(id);
            return Ok(result);
        }

        [HttpGet("{startIndex}/{limit}")]
        public IActionResult GetPagingGenres(int startIndex, int limit)
        {
            var result = _genreService.GetPagingGenres(startIndex, limit);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetLengthOfGenres()
        {
            var result = _genreService.GetAllGenres().Count();
            return Ok(result);
        }
    }
}
