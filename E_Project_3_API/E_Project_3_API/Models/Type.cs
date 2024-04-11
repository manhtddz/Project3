using System.ComponentModel.DataAnnotations;

namespace E_Project_3_API.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public bool Active { get; set; } = true;
        public virtual List<Category> Categories { get; set; }
    }
}
