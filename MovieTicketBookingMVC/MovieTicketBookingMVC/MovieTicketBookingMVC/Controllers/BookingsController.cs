using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MovieTicketBookingMVC.Models;

namespace MovieTicketBookingMVC.Controllers
{
    public class BookingsController : Controller
    {
        private readonly MovieDbContext db = new MovieDbContext();

        [HttpGet]
        public ActionResult Create(int? movieId)
        {
            if (movieId == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var movie = db.Movies.Find(movieId);
            if (movie == null || !movie.IsActive) return HttpNotFound();

            return View(new BookingViewModel
            {
                MovieId = movie.MovieId,
                MovieTitle = movie.Title,
                TicketPrice = movie.TicketPrice,
                ShowDate = DateTime.Today.AddDays(1),
                ShowTime = "06:00 PM",
                TicketCount = 1
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingViewModel model)
        {
            var movie = db.Movies.Find(model.MovieId);
            if (movie == null || !movie.IsActive) return HttpNotFound();

            model.MovieTitle = movie.Title;
            model.TicketPrice = movie.TicketPrice;

            if (model.ShowDate.Date < DateTime.Today)
                ModelState.AddModelError("ShowDate", "Please choose today or a future date.");

            var seats = (model.SeatNumbers ?? "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim().ToUpperInvariant()).Where(s => s.Length > 0).Distinct().ToArray();
            if (seats.Length != model.TicketCount)
                ModelState.AddModelError("SeatNumbers", "Enter one unique seat number for each ticket (e.g. A1,A2).");

            if (ModelState.IsValid)
            {
                var booking = new Booking
                {
                    CustomerName = model.CustomerName,
                    Email = model.Email,
                    Phone = model.Phone,
                    MovieId = movie.MovieId,
                    ShowTime = model.ShowTime,
                    ShowDate = model.ShowDate.Date,
                    TicketCount = model.TicketCount,
                    SeatNumbers = string.Join(", ", seats),
                    TotalAmount = movie.TicketPrice * model.TicketCount,
                    BookedAt = DateTime.Now,
                    IsCancelled = false
                };
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Confirmation", new { id = booking.BookingId });
            }

            return View(model);
        }

        public ActionResult Confirmation(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var booking = db.Bookings.Include("Movie").FirstOrDefault(b => b.BookingId == id);
            if (booking == null) return HttpNotFound();
            return View(booking);
        }

        [HttpGet]
        public ActionResult MyBookings(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return View(new System.Collections.Generic.List<Booking>());
            ViewBag.Email = email;
            return View(db.Bookings.Include("Movie").Where(b => b.Email == email).OrderByDescending(b => b.BookedAt).ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancel(int id, string email)
        {
            var booking = db.Bookings.Find(id);
            if (booking == null) return HttpNotFound();
            if (!string.Equals(booking.Email, email, StringComparison.OrdinalIgnoreCase))
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            if (booking.ShowDate.Date >= DateTime.Today)
            {
                booking.IsCancelled = true;
                db.SaveChanges();
            }
            return RedirectToAction("MyBookings", new { email = email });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
