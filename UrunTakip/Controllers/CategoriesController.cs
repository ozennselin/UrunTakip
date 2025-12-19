using Microsoft.AspNetCore.Mvc;
using UrunTakip.Data;

namespace UrunTakip.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly NorthwindDB _db;

        public CategoriesController(NorthwindDB db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //CRUD=>Insert, Update, Delete,Read(List) amaç bunları Entity Framework ile yapacağız
            var liste = _db.Categories.ToList();
            return View(liste);
        }
    }
}
