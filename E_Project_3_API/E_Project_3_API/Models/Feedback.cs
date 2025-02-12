using System.ComponentModel.DataAnnotations;

namespace E_Project_3_API.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public virtual User User { get; set; }
    }
}
