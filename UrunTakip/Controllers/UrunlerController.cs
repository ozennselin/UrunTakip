using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using UrunTakip.Data;
using UrunTakip.Data.Entities;
using UrunTakip.Mapping;

namespace UrunTakip.Controllers
{
    //https://bootsnipp.com/snippets/2P90=> template linki
    public class UrunlerController : Controller
    {
        private readonly NorthwindDB _db;//DI=> Dependency Injection
        private readonly ProductMapping _mapping;

        public UrunlerController(NorthwindDB db,ProductMapping mapping)
        {
            _db = db;//DI devamı
            _mapping = mapping;

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

        [HttpGet]
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
        }
        private void KategoriYukle()
        {
            var getirKategori = _db.Categories.ToList();
            var kategoriler = new SelectList(getirKategori, "CategoryId", "CategoryName");
            ViewBag.kategoriList = kategoriler;
        }

        [HttpGet]
        public IActionResult UrunGuncelle(int id)
        {
            KategoriYukle();
            var secilenUrun = _db.Products.Where(k => k.ProductID == id).FirstOrDefault();

            #region DropDownList için Category ve supplier viewbag ile yüklenecek kodlar

            /* int gelenKategoryId = (int)secilenUrun.CategoryID;
             string kategoriAdi = _db.Categories.Where(k => k.CategoryId == gelenKategoryId).FirstOrDefault().CategoryName;
             ViewBag.secilenKategori = kategoriAdi;

             int gelenSupplierId = (int)secilenUrun.SupplierID;
             string tedarikciAdi = _db.Suppliers.Where(k => k.SupplierID == gelenSupplierId).FirstOrDefault().CompanyName;
             ViewBag.secilenTedarikci = tedarikciAdi;    
            return View(secilenUrun);
            */
            #endregion
            
            var mapDto = _mapping.UpdateMapping(secilenUrun);

            return View(mapDto);
        }
        [HttpPost]
        public IActionResult UrunGuncelle(Products product)
        {
            Products guncellecekUrun = _db.Products.Where(k => k.ProductID == product.ProductID).FirstOrDefault();//Linq ,=> Lambda expresion

            guncellecekUrun.ProductName = product.ProductName;
            guncellecekUrun.SupplierID = product.SupplierID;
            guncellecekUrun.CategoryID = product.CategoryID;
            guncellecekUrun.QuantityPerUnit = product.QuantityPerUnit;
            guncellecekUrun.UnitPrice = product.UnitPrice;
            guncellecekUrun.UnitsInStock = product.UnitsInStock;
            guncellecekUrun.UnitsOnOrder = product.UnitsOnOrder;
            guncellecekUrun.ReorderLevel = product.ReorderLevel;
            guncellecekUrun.Discontinued = product.Discontinued;

            int sonuc = _db.SaveChanges();//güncelleme için sadece bu yeterli

            if (sonuc > 0)
            {
                ViewBag.mesaj = "Güncellem işlemi başarılı oldu.";
                KategoriYukle();
                //return View(); bunun yerine listeye yönlendirelim

                return RedirectToAction("UrunList");
            }
            else
            {
                ViewBag.mesaj = "Güncellem işlemi başarısız oldu.";
                KategoriYukle();
                //başarısız
                return View();
            }
        }

        [HttpGet]
        public IActionResult UrunSil(int id)
        {
            var secilenUrun = _db.Products.Where(k => k.ProductID == id).FirstOrDefault();
            return View(secilenUrun);
        }

        [HttpPost,ActionName("UrunSil")]//?? aynı isim, aynı parametre ile overload edilemez
        public IActionResult UrunSilPost(int id)
        {
            var silinecekUrun = _db.Products.Where(k => k.ProductID == id).FirstOrDefault();
            _db.Products.Remove(silinecekUrun);//EF ile db den data silme
            _db.SaveChanges();//Silme işlemini db ye kaydet
            return RedirectToAction("UrunList");
        }





    }
}
