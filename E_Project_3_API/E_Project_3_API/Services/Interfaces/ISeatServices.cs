using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;

namespace E_Project_3_API.Services.Interfaces
{
    public interface ISeatServices
    {
        List<SeatsResponse> GetAllSeats();
        SeatsResponse GetSeat(int id);
        SeatsModifyResponse CreateSeat(SeatRequest request);
        SeatsModifyResponse UpdateSeat(int id, SeatRequest request);
        SeatsModifyResponse DeleteSeat(int id);
    }
}
