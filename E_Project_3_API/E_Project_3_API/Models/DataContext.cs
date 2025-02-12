using Microsoft.EntityFrameworkCore;

namespace E_Project_3_API.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
