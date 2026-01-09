using Humanizer;
using UrunTakip.Data;
using UrunTakip.Data.Entities;
using UrunTakip.DTO.ProductDTOS;

namespace UrunTakip.Mapping;

public class ProductMapping
{

    NorthwindDB _db;

    public ProductMapping(NorthwindDB db)
    {
        _db = db;
    }

    //
    //Lazım mı???
    public ProductInsertDto InsertMapping(Products product)
    {
        ProductInsertDto dto = new ProductInsertDto();
        dto.ProductName = product.ProductName;
        dto.SupplierId = product.SupplierID;
        dto.CategoryID = product.CategoryID;
        dto.QuantityPerUnit = product.QuantityPerUnit;
        dto.UnitPrice = product.UnitPrice;
        dto.UnitsInStock = product.UnitsInStock;
        dto.UnitsOnOrder = product.UnitsOnOrder;
        dto.ReorderLevel = product.ReorderLevel;
        dto.Discontinued = product.Discontinued;
        dto.CategoryName = _db.Categories.Find(product.CategoryID)?.CategoryName;
        dto.SupplierName = _db.Suppliers.Find(product.SupplierID)?.CompanyName;

        return dto;
    }

    public ProductUpdateDto UpdateMapping(Products product)
    {
        ProductUpdateDto dto = new ProductUpdateDto();
        dto.ProductName = product.ProductName;
        dto.SupplierID = product.SupplierID;
        dto.CategoryID = product.CategoryID;
        dto.QuantityPerUnit = product.QuantityPerUnit;
        dto.UnitPrice = product.UnitPrice;
        dto.UnitsInStock = product.UnitsInStock;
        dto.UnitsOnOrder = product.UnitsOnOrder;
        dto.ReorderLevel = product.ReorderLevel;
        dto.Discontinued = product.Discontinued;
        dto.CategoryName = _db.Categories.Find(product.CategoryID)?.CategoryName;
        dto.SupplierName = _db.Suppliers.Find(product.SupplierID)?.CompanyName;

        return dto;
    }

    public List<ProductListDto> ListMapping(List<Products> products)
    {
        List<ProductListDto> list = new List<ProductListDto>();

        foreach (Products product in products)
        {
            var dto = new ProductListDto()
            {
                ProductName = product.ProductName,
                SupplierID = product.SupplierID,
                CategoryID = product.CategoryID,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.Discontinued,
                CategoryName = _db.Categories.Find(product.CategoryID)?.CategoryName,
                SupplierName = _db.Suppliers.Find(product.SupplierID)?.CompanyName
            };
            list.Add(dto);
        }


        return list;
    }
}
