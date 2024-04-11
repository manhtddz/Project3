using E_Project_3_API.DTO.Error;

namespace E_Project_3_API.DTO.Response
{
    public class TicketResponse
    {
        public int Id { get; set; }
        public bool Active { get; set; } = true;
        public int MovieId { get; set; }
        public int SeatId { get; set; }
        public int TheaterId { get; set; }
        public int ShowtimeId { get; set; }
        public int DateId { get; set; }
        public int UserId { get; set; }
       
    }

    public class TicketModifyResponse
    {
        public bool isModified { get; set; } = false;
        public TicketError Error { get; set; } = new TicketError();
       
    }
}
