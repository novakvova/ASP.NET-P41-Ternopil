using FluentValidation;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQRCode.Data;
using WebQRCode.Data.Entities.Identity;
using WebQRCode.Extensions;
using WebQRCode.Filters;
using WebQRCode.Interfaces;
using WebQRCode.Services;
using WebQRCode.Validators.Account;

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

builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(); //Кажемо, що у нас є swagger

const string reactCorsPolicy = "ReactClient";
builder.Services.AddCors(options =>
{
    options.AddPolicy(reactCorsPolicy, policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<LoginModelValidator>();

// MVC Filter and Options
builder.Services.Configure<MvcOptions>(options =>
{
    options.Filters.Add<ValidationFilter>();
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = long.MaxValue;
    options.MultipartHeadersLengthLimit = int.MaxValue;
});

var app = builder.Build();

app.UseCors(reactCorsPolicy);

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
