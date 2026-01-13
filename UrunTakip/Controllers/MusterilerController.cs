using Microsoft.AspNetCore.Mvc;
using UrunTakip.Data;
using UrunTakip.Data.Entities;
using UrunTakip.DTO.CustomerDTOS;
using UrunTakip.Mapping;

namespace UrunTakip.Controllers
{
    public class MusterilerController : Controller
    {
        private readonly NorthwindDB _db;
        private readonly CustomerMapping _mapping;

        public MusterilerController(NorthwindDB db)
        {
            _db = db;
            _mapping = new CustomerMapping(db);
        }

        
        public IActionResult Index()
        {
            var liste = _db.Customers.ToList();
            List<CustomerListDto>dtoListe=new List<CustomerListDto>();
            foreach(var item  in liste)
            {
                dtoListe.Add(_mapping.ListMapping(item));
            }
            return View(dtoListe);
        }

      
        [HttpGet]
        public IActionResult CustomerEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CustomerEkle(CustomerInsertDto dto)
        {
            Customers entity = _mapping.InsertDtoToEntity(dto);
            _db.Customers.Add(entity);
            _db.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult CustomerGuncelle(string id)
        {
            var customer = _db.Customers.FirstOrDefault(x => x.CustomerID == id);
            var dto = _mapping.UpdateMapping(customer);
            return View(dto);
        }

        [HttpPost]
        public IActionResult CustomerGuncelle(CustomerUpdateDto dto)
        {
            var customer = _db.Customers.FirstOrDefault(x => x.CustomerID == dto.CustomerID);

            customer.CompanyName = dto.CompanyName;
            customer.ContactName = dto.ContactName;
            customer.City = dto.City;

            _db.SaveChanges();
            return View(dto);
        }

        [HttpGet]
        public IActionResult CustomerSil(string id)
        {
            var customer = _db.Customers.FirstOrDefault(x => x.CustomerID == id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult CustomerSil(Customers customer)
        {
            var silinecek = _db.Customers.FirstOrDefault(x => x.CustomerID == customer.CustomerID);
            _db.Customers.Remove(silinecek);
            _db.SaveChanges();
            return View();
        }
    }
}