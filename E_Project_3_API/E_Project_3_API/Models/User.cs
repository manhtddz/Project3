using System.ComponentModel.DataAnnotations;

namespace E_Project_3_API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]  
        public string PasswordHash { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool Active { get; set; } = true;
        public bool Role { get; set; } = false;
        public virtual List<Ticket>? Tickets { get; set; }
    }
}
