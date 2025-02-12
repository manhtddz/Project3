using System.ComponentModel.DataAnnotations;

namespace E_Project_3_API.Models
{
    public class Date
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Day { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
    }
}
