using Microsoft.AspNetCore.Mvc;
using UrunTakip.Data;
using UrunTakip.Data.Entities;

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

        [HttpGet]
        public IActionResult CategoryEkle()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult CategoryEkle(Categories category)
        {
            Categories ekle=new Categories();
            ekle.CategoryName= category.CategoryName;
            ekle.Description= category.Description;

            _db.Categories.Add(ekle);
            int sonuc=_db.SaveChanges();

            if(sonuc>0)
            {
                ViewBag.mesaj = "Kategori ekleme işlemi başarılı oldu.";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.mesaj = "Kategori ekleme işlemi başarısız oldu.";
                return View();
            }
        }

        [HttpGet]

        public IActionResult CategoryGuncelle(int id)
        {
            var secilenKategori= _db.Categories.Where(k=>k.CategoryId==id).FirstOrDefault();
            return View(secilenKategori);
        }

        [HttpPost]

        public IActionResult CategoryGuncelle(Categories category)
        {
            Categories guncellenecekKategori=_db.Categories.Where(k=>k.CategoryId == category.CategoryId).FirstOrDefault();
            guncellenecekKategori.CategoryName= category.CategoryName;
            guncellenecekKategori.Description= category.Description;

            int sonuc = _db.SaveChanges();

            if(sonuc>0)
            {
                ViewBag.mesaj = "Kategori güncelleme işlemi başarılı oldu.";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.mesaj = "Kategori güncelleme işlemi başarısız oldu.";
                return View(category);
            }
        }

        [HttpGet]

        public IActionResult CategorySil(int id)
        {
            var secilenKategori=_db.Categories.Where(k=>k.CategoryId== id).FirstOrDefault();
            return View(secilenKategori);
        }

        [HttpPost,ActionName("CategorySil")]
        public IActionResult CategorySilPost(int id)
        {
            var silinecekKategori=_db.Categories.Where(k=>k.CategoryId==id).FirstOrDefault();

            _db.Categories.Remove(silinecekKategori);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }




    }
    
}
