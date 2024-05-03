
using E_Project_3_API.Models;
using System.ComponentModel.DataAnnotations;

public class Movie
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; } = true;
    public virtual Shop Shop { get; set; }
    public virtual Genre Genre { get; set; }
    public virtual List<Ticket> Tickets { get; set; }
}
