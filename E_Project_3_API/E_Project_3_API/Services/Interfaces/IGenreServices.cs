using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;

namespace E_Project_3_API.Services.Interfaces
{
    public interface IGenreServices
    {
        List<GenreResponse> GetAllGenres();
        GenreResponse GetGenreById(int id);
        GenreModifyResponse CreateGenre(GenreRequest genre);
        GenreModifyResponse UpdateGenre(int id, GenreRequest genre);
        GenreModifyResponse DeleteGenre(int id);
        List<GenreResponse> GetPagingGenres(int startIndex, int limit);
    }
}
