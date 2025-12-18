using System.ComponentModel.DataAnnotations;

namespace UrunTakip.Data.Entities
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        //public string Picture { get; set; }
    }
}
