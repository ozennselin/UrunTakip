using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UrunTakip.Data;
using UrunTakip.Data.Entities;

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

        [HttpPost]//Açılan Index sayfası içinde form elementinin özelliklerini kullanmak için var
                  //public IActionResult UrunEkle(string ProductName,int PupplierID,int CategoryID,int QuantityPerUnit,decimal UnitPrice,int UnitsInStock,short UnitsOnOrder,short ReorderLevel,bool Discontinued)//bunun yerine Product nesne kullanılacak aşağıda gibi
        public IActionResult UrunEkle(Products product)
        {
            //doldurulan data için burda Db ye Insert işlemi yapılacak şekilde işlem yapılmalıdır
            Products ekle = new Products();
            ekle.ProductName = product.ProductName;
            ekle.SupplierID = product.SupplierID;
            ekle.CategoryID = product.CategoryID;
            ekle.QuantityPerUnit = product.QuantityPerUnit;
            ekle.UnitPrice = product.UnitPrice;
            ekle.UnitsInStock = product.UnitsInStock;
            ekle.UnitsOnOrder = product.UnitsOnOrder;
            ekle.ReorderLevel = product.ReorderLevel;
            ekle.Discontinued = product.Discontinued;
            _db.Products.Add(ekle);//ekle olan nesneye ,product parametresinden gelen datalar atandıktan sonra DbSet e ekleme yapıldı   
            int sonuc = _db.SaveChanges();//Değişiklikleri veritabanına  kaydet
            if (sonuc > 0)
            {
                ViewBag.eklemeDurum = "Ekleme işlemi başarılı oldu.";
                KategoriYukle();
                //başarılı
                return View();//Ekleme başarılı ise UrunList sayfasına yönlendir
            }
            else
            {
                ViewBag.eklemeDurum = "Ekleme işlemi başarısız oldu.";
                KategoriYukle();
                //başarısız
                return View();
            }
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
