using System.ComponentModel.DataAnnotations;

namespace MovieTicketBookingMVC.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required, StringLength(60)]
        public string Genre { get; set; }

        [Required, StringLength(30)]
        public string Language { get; set; }

        [Range(1, 500)]
        public int DurationMinutes { get; set; }

        [Required, StringLength(500)]
        public string Description { get; set; }

        [Required, StringLength(500)]
        public string PosterUrl { get; set; }

        [Range(0, 5000)]
        public decimal TicketPrice { get; set; }

        public bool IsActive { get; set; }
    }
}
