using Microsoft.EntityFrameworkCore;//DbContext ve DbSet için gerekli kütüphanedir
using UrunTakip.Data.Entities;

namespace UrunTakip.Data
{
    public class NorthwindDB:DbContext
        //DbContext=> EF tarafında veritabanına bağlanmak için hazırlanmış bir class yapısıdır. DB bağlanmak için bazı özellikler gerekli , bu özellikleri DbContext içinde barındırmaktadır
    {
        //DB de yer alan tabloların yazıldığı yer

        public NorthwindDB(DbContextOptions<NorthwindDB> options):base(options) { }//??

        public DbSet<Products> Product { get; set; }
        public DbSet<Categories> Category { get; set; }
        public DbSet<Customers> Customer { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
