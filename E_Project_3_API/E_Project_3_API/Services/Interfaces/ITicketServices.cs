using System.Collections.Generic;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;

namespace E_Project_3_API.Services.Interfaces
{
    public interface ITicketServices
    {
        TicketModifyResponse CreateTicket(TicketRequest request);
        List<TicketResponse> GetAllTickets();
        TicketResponse GetTicketById(int id);
        TicketModifyResponse UpdateTicket(int id, TicketRequest request);
        TicketModifyResponse DeleteTicket(int id);
        List<TicketResponse> GetTicketByMovieDateShowtime(int movieId, int dateId, int showtimeId);
        List<TicketResponse> GetTicketByMovie(int movieId);
        TicketModifyResponse BookingTicket(int id, int userId);
    }
}
