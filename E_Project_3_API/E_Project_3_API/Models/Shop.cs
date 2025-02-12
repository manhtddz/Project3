using System.ComponentModel.DataAnnotations;

namespace E_Project_3_API.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Logo { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public bool Active { get; set; } = true;
        public virtual List<Product> Products { get; set; }
        public virtual List<Movie> Movies { get; set; }
    }
}
