using System.ComponentModel.DataAnnotations;

namespace E_Project_3_API.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool Active { get; set; } = true;
        public virtual Movie Movie { get; set; }
        public virtual Theater Theater { get; set; }
        public virtual Seat Seat { get; set; }
        public virtual Showtime Showtime { get; set; }
        public virtual Date Date { get; set; }
        public virtual User? User { get; set; }
    }
}
