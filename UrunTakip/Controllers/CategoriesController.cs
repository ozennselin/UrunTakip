using Microsoft.AspNetCore.Mvc;
using UrunTakip.Data;
using UrunTakip.DTO.CategoryDTOS;
using UrunTakip.Mapping;

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
            var liste = _db.Categories.ToList();
            return View(liste);
        }
    }
}
