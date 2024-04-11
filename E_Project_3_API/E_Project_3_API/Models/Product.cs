using System.ComponentModel.DataAnnotations;

namespace E_Project_3_API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool Active { get; set; } = true;
        public virtual Shop Shop { get; set; }
        public virtual Category Category { get; set; }
    }
}
