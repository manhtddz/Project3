namespace E_Project_3_API.DTO.Request
{
    public class TicketRequest
    {
        public int MovieId { get; set; }
        public int SeatId { get; set; }
        public int TheaterId { get; set; }
        public int ShowtimeId { get; set; }
        public int DateId { get; set; }
        public int UserId { get; set; } = 0;
    }
}
