using System.ComponentModel.DataAnnotations;

namespace E_Project_3_API.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<Movie> Movies { get; set; }
    }
}
