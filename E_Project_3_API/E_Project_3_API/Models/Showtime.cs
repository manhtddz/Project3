using System.ComponentModel.DataAnnotations;

namespace E_Project_3_API.Models
{
    public class Showtime
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
        //bỏ isActive đi
        //bỏ movie id đi
    }
}
