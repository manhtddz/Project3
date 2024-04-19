using System.Collections.Generic;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;

namespace E_Project_3_API.Services.Interfaces
{
    public interface IMovieServices
    {
        IEnumerable<MovieResponse> GetAllMovies();
        MovieResponse GetMovieById(int id);
        MovieModifyResponse CreateMovie(MovieRequest movieRequest);
        MovieModifyResponse UpdateMovie(int id, MovieRequest movieRequest);
        MovieModifyResponse DeleteMovie(int id);
        List<MovieResponse> GetPagingMovies(int startIndex, int limit);

    }
}
