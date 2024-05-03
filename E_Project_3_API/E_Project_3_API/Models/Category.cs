using System.ComponentModel.DataAnnotations;

namespace E_Project_3_API.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; } = true;
        public virtual Type Type { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
