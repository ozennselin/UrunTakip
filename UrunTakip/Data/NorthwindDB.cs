using Microsoft.EntityFrameworkCore;//DbContext ve DbSet için gerekli kütüphanedir
using UrunTakip.Data.Entities;

namespace UrunTakip.Data
{
    public class NorthwindDB : DbContext
    //DbContext=> EF tarafında veritabanına bağlanmak için hazırlanmış bir class yapısıdır. DB bağlanmak için bazı özellikler gerekli , bu özellikleri DbContext içinde barındırmaktadır
    {
        //DB de yer alan tabloların yazıldığı yer

        public NorthwindDB(DbContextOptions<NorthwindDB> options) : base(options) { }//??

        #region DB Tablolar=> Code First ile ORM
        //ORM=> Object relation Mapping//Manage
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
