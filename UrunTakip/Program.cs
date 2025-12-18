using Microsoft.EntityFrameworkCore;
using UrunTakip.Data;


//yukarý alan kütüphane laýndýr
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Veritabaný baðlama iþlemi


var baglantiAdresi = builder.Configuration.GetConnectionString("NorthwindDB");//Bu adres SQL Server da yer alan NorthwindDB veritanýnýn adresidir
builder.Services.AddDbContext<NorthwindDB>(x => x.UseSqlServer(baglantiAdresi));//NorthwindDB adýnda class ýma adresi verilen veritabaný adresi içeren baglantiAdresi adresindeki veritabanýný kullan(c# tarafýnda db yi SQL serverdaki DB ye eþitliyor)

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
