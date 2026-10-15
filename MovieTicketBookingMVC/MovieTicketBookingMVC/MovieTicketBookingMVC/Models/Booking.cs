using System;
using System.ComponentModel.DataAnnotations;

namespace MovieTicketBookingMVC.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required, StringLength(100)]
        public string CustomerName { get; set; }

        [Required, EmailAddress, StringLength(150)]
        public string Email { get; set; }

        [Required, StringLength(20)]
        public string Phone { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        [Required, StringLength(20)]
        public string ShowTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime ShowDate { get; set; }

        [Range(1, 10)]
        public int TicketCount { get; set; }

        [Required, StringLength(300)]
        public string SeatNumbers { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime BookedAt { get; set; }
        public bool IsCancelled { get; set; }
    }
}
