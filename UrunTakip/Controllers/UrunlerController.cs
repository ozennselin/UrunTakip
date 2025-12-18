using Microsoft.AspNetCore.Mvc;
using UrunTakip.Data;

namespace UrunTakip.Controllers
{
    //https://bootsnipp.com/snippets/2P90=> template linki
    public class UrunlerController : Controller
    {
        private readonly NorthwindDB _db;//DI=> Dependency Injection

        public UrunlerController(NorthwindDB db)
        {
            _db= db;//DI devamı
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UrunList()
        {
            //NorthwindDB db = new NorthwindDB();
            var liste = _db.Products.ToList();//ToList()=> Linq
            //select *from Products=> ToList()
            //var query = _db.Product.Where(p => p.ProductId == 9).FirstOrDefault();//select *from Products  where ProductID=9


            return View(liste);
        }

        public IActionResult UrunEkle()
        {
            return View();
        }
    }
}
