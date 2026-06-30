using Microsoft.EntityFrameworkCore;
using WebHike.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//DI - dependecy injection
string strConn = builder.Configuration
    .GetConnectionString("MyWebHikeConnection") ?? "";

builder.Services.AddDbContext<HikeDbContext>(opt =>
    opt.UseNpgsql(strConn));

builder.Services.AddControllersWithViews();

var app = builder.Build();

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
