using System.Linq;
using System.Net;
using System.Web.Mvc;
using MovieTicketBookingMVC.Models;

namespace MovieTicketBookingMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieDbContext db = new MovieDbContext();

        public ActionResult Index(string search, string genre)
        {
            var movies = db.Movies.Where(m => m.IsActive);
            if (!string.IsNullOrWhiteSpace(search))
                movies = movies.Where(m => m.Title.Contains(search) || m.Language.Contains(search));
            if (!string.IsNullOrWhiteSpace(genre))
                movies = movies.Where(m => m.Genre == genre);
            ViewBag.Search = search;
            ViewBag.Genres = db.Movies.Where(m => m.IsActive).Select(m => m.Genre).Distinct().ToList();
            return View(movies.OrderBy(m => m.Title).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var movie = db.Movies.Find(id);
            if (movie == null || !movie.IsActive) return HttpNotFound();
            return View(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
