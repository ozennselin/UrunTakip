using Microsoft.AspNetCore.Mvc;

namespace UrunTakip.Controllers
{
    public class UrunlerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UrunList()
        {
            return View();
        }

        public IActionResult UrunEkle()
        {
            return View();
        }
    }
}
