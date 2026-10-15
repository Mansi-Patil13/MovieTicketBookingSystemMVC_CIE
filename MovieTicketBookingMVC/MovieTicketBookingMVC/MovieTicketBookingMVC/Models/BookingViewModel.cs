using System;
using System.ComponentModel.DataAnnotations;

namespace MovieTicketBookingMVC.Models
{
    public class BookingViewModel
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public decimal TicketPrice { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Full name")]
        public string CustomerName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        [Display(Name = "Phone number")]
        public string Phone { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = "Show date")]
        public DateTime ShowDate { get; set; }

        [Required]
        [Display(Name = "Show time")]
        public string ShowTime { get; set; }

        [Range(1, 10)]
        [Display(Name = "Number of tickets")]
        public int TicketCount { get; set; }

        [Required]
        [Display(Name = "Seat numbers (e.g. A1,A2)")]
        public string SeatNumbers { get; set; }
    }
}
