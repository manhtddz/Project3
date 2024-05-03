using System.ComponentModel.DataAnnotations;

namespace E_Project_3_API.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        //thêm tên ghế
        public string Name { get; set; }
        public virtual List<Ticket> Tickets { get; set; }

    }
}
