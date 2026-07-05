using Microsoft.EntityFrameworkCore;
using WebHike.Data;
using WebHike.Interfaces;
using WebHike.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//DI - dependecy injection
string strConn = builder.Configuration
    .GetConnectionString("MyWebHikeConnection") ?? "";

builder.Services.AddDbContext<HikeDbContext>(opt =>
    opt.UseNpgsql(strConn));

builder.Services.AddScoped<IImageService, ImageOptimizationService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

var dirName = "images";
var dirCurrent = Directory.GetCurrentDirectory();
var path = Path.Combine(dirCurrent, "wwwroot", dirName);
Directory.CreateDirectory(path); //автоматично стоврить images

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Main}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
