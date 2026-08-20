using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebQRCode.Data;
using WebQRCode.Data.Entities.Identity;
using WebQRCode.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<QRCodeDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("MyQRCodeConnection")));

builder.Services.AddIdentity<UserEntity, RoleEntity>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
})
    .AddEntityFrameworkStores<QRCodeDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(); //Кажемо, що у нас є swagger

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

await app.SeedData();

app.UseSwagger(); //У нас використовується Swagger
app.UseSwaggerUI(); //У нас доступний Swagger інтерфейс

app.UseAuthorization();
//app.UseHttpsRedirection();

app.MapControllers();

app.Run();
