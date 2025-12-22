using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            //Data alışverişini aşağıdaki 3 yapı ile de yapabiliriz
            //1)ViewBag.kategori1=_db.Categories.ToList();//ViewBag dinamik bir yapı
            //2) TempData["kategori2"]=_db.Categories.ToList();//TempData=> bir sayfadan diğerine veri taşımak için kullanılır
            //3) ViewData["kategori3"]=_db.Categories.ToList();//ViewData=> ViewBag gibi dinamik bir yapı ama sözlük yapısında çalışır

            //List<string> text=new List<string>();
            //text.Add("Bilgisayar");
            //text.Add("Telefon");
            //text.Add("Tablet");
            //text.Add("Beyaz Eşya");
            //ViewBag.kategory12=text;
            //var getirKategori=_db.Categories.ToList();
            //////using Microsoft.AspNetCore.Mvc.Rendering; eklenmeli
            ///////genelde SelctList yapıları value ve Text olmak üzere 2 parametre alır
            //var kategoriler = new SelectList(getirKategori, "CategoryId", "CategoryName");
            //ViewBag.kategoriList = kategoriler;
            KategoriYukle();
            return View();
        }

        private void KategoriYukle()
        {
            var getirKategori= _db.Categories.ToList();
            var kategoriler = new SelectList(getirKategori, "CategoryId", "CategoryName");
            ViewBag.kategoriList = kategoriler;
        }
    }
}
