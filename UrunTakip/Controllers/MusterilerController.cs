using Microsoft.AspNetCore.Mvc;
using UrunTakip.Data;

namespace UrunTakip.Controllers
{
    public class MusterilerController : Controller
    {
        private readonly NorthwindDB _db;

        public MusterilerController(NorthwindDB db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var liste = _db.Customers?.ToList();
            return View(liste);
        }
    }
}