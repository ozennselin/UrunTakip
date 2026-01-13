using UrunTakip.Data;
using UrunTakip.Data.Entities;
using UrunTakip.DTO.CustomerDTOS;

namespace UrunTakip.Mapping
{
    public class CustomerMapping
    {
        NorthwindDB _db;

        public CustomerMapping(NorthwindDB db)
        {
            _db = db;
        }

       
        public CustomerListDto ListMapping(Customers customer)
        {
            CustomerListDto dto = new CustomerListDto();
            dto.CustomerID = customer.CustomerID;
            dto.CompanyName = customer.CompanyName;
            dto.ContactName = customer.ContactName;
            dto.ContactTitle = customer.ContactTitle;
            dto.Address = customer.Address;
            dto.City = customer.City;
            dto.Region = customer.Region;
            dto.PostalCode = customer.PostalCode;
            dto.Country = customer.Country;
            dto.Phone = customer.Phone;
            dto.Fax = customer.Fax;
            return dto;
        }

    
        public CustomerUpdateDto UpdateMapping(Customers customer)
        {
            CustomerUpdateDto dto = new CustomerUpdateDto();
            dto.CustomerID = customer.CustomerID;
            dto.CompanyName = customer.CompanyName;
            dto.ContactName = customer.ContactName;
            dto.ContactTitle = customer.ContactTitle;
            dto.Address = customer.Address;
            dto.City = customer.City;
            dto.Region = customer.Region;
            dto.PostalCode = customer.PostalCode;
            dto.Country = customer.Country;
            dto.Phone = customer.Phone;
            dto.Fax = customer.Fax;
            return dto;
        }

       
        public Customers InsertDtoToEntity(CustomerInsertDto dto)
        {
            Customers entity = new Customers();
            entity.CustomerID = dto.CustomerID;
            entity.CompanyName = dto.CompanyName;
            entity.ContactName = dto.ContactName;
            entity.ContactTitle = dto.ContactTitle;
            entity.Address = dto.Address;
            entity.City = dto.City;
            entity.Region = dto.Region;
            entity.PostalCode = dto.PostalCode;
            entity.Country = dto.Country;
            entity.Phone = dto.Phone;
            entity.Fax = dto.Fax;
            return entity;
        }
    }
}