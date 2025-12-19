using System.ComponentModel.DataAnnotations;

namespace UrunTakip.Data.Entities
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string? Description { get; set; } = string.Empty;//bu kolon db de nullable o nedenler ? ya da string.Empty yaptık
        //public string Picture { get; set; }
    }
}
