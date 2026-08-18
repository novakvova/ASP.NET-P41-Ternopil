var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

app.UseSwagger(); //У нас використовується Swagger
app.UseSwaggerUI(); //У нас доступний Swagger інтерфейс

app.UseAuthorization();
//app.UseHttpsRedirection();

app.MapControllers();

app.Run();
