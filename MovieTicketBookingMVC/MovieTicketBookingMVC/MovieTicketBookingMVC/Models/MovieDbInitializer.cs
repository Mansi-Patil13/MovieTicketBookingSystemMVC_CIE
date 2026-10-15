using System.Data.Entity;

namespace MovieTicketBookingMVC.Models
{
    public class MovieDbInitializer : CreateDatabaseIfNotExists<MovieDbContext>
    {
        protected override void Seed(MovieDbContext context)
        {
            context.Movies.Add(new Movie
            {
                Title = "The Last Horizon", Genre = "Adventure", Language = "English",
                DurationMinutes = 128,
                Description = "A team of explorers races against time to uncover a hidden world beyond the horizon.",
                PosterUrl = "https://images.unsplash.com/photo-1440404653325-ab127d49abc1?w=800",
                TicketPrice = 220, IsActive = true
            });
            context.Movies.Add(new Movie
            {
                Title = "Midnight Promise", Genre = "Romance", Language = "Hindi",
                DurationMinutes = 116,
                Description = "Two strangers meet on a rainy evening and discover that the city has a story of its own.",
                PosterUrl = "https://images.unsplash.com/photo-1489599849927-2ee91cede3ba?w=800",
                TicketPrice = 180, IsActive = true
            });
            context.Movies.Add(new Movie
            {
                Title = "Code Red", Genre = "Thriller", Language = "English",
                DurationMinutes = 134,
                Description = "A cyber investigator follows a trail of clues before a city-wide blackout begins.",
                PosterUrl = "https://images.unsplash.com/photo-1517604931442-7e0c8ed2963c?w=800",
                TicketPrice = 250, IsActive = true
            });
            context.Movies.Add(new Movie
            {
                Title = "Laughing Matters", Genre = "Comedy", Language = "Hindi",
                DurationMinutes = 108,
                Description = "A chaotic family reunion turns into a comedy of errors that nobody will forget.",
                PosterUrl = "https://images.unsplash.com/photo-1478720568477-152d9b164e26?w=800",
                TicketPrice = 160, IsActive = true
            });
            context.Movies.Add(new Movie
            {
                Title = "Ocean of Dreams", Genre = "Drama", Language = "Gujarati",
                DurationMinutes = 122,
                Description = "A young artist returns home and finds inspiration in the people and memories she left behind.",
                PosterUrl = "https://images.unsplash.com/photo-1518676590629-3dcbd9c5a5c9?w=800",
                TicketPrice = 190, IsActive = true
            });
            context.Movies.Add(new Movie
            {
                Title = "Shadow Protocol", Genre = "Action", Language = "English",
                DurationMinutes = 141,
                Description = "An undercover agent must make one final choice when the mission becomes personal.",
                PosterUrl = "https://images.unsplash.com/photo-1500530855697-b586d89ba3ee?w=800",
                TicketPrice = 240, IsActive = true
            });
            base.Seed(context);
        }
    }
}
