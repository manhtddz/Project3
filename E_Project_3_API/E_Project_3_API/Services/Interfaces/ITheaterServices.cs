using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;

namespace E_Project_3_API.Services.Interfaces
{
    public interface ITheaterServices
    {
        TheaterModifyResponse CreateTheater(TheaterRequest request);
        List<TheaterResponse> GetAllTheaters();
        TheaterResponse GetTheater(int id);
        TheaterModifyResponse UpdateTheater(int id, TheaterRequest request);
        TheaterModifyResponse DeleteTheater(int id);
        List<TheaterResponse> GetPagingTheaters(int startIndex, int limit);
    }
}
