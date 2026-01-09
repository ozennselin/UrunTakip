using System.ComponentModel.DataAnnotations;

namespace UrunTakip.Data.Entities;

public class Suppliers
{
    [Key]
    public int SupplierID { get; set; }
    public string CompanyName { get; set; }
    public string Phone { get; set; }
}
