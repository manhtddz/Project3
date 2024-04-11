using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;

namespace E_Project_3_API.Services.Interfaces
{
    public interface IShowtimeServices
    {
        ShowtimeModifyResponse CreateShowtime(ShowtimeRequest request);
        List<ShowtimeResponse> GetAllShowtimes();
        ShowtimeResponse GetShowtime(int id);
        //ShowtimeModifyResponse UpdateShowtime(int id, ShowtimeRequest request);
        ShowtimeModifyResponse DeleteShowtime(int id);
    }
}
