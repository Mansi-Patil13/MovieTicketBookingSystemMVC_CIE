using System.Data.Entity;

namespace MovieTicketBookingMVC.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext() : base("MovieTicketBookingConnection") { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
