using System.Linq;
using System.Web.Mvc;
using MovieTicketBookingMVC.Models;

namespace MovieTicketBookingMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieDbContext db = new MovieDbContext();

        public ActionResult Index()
        {
            return View(db.Movies.Where(m => m.IsActive).OrderBy(m => m.Title).Take(6).ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
