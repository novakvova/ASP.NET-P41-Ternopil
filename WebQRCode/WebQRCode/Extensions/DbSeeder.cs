using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebQRCode.Constants;
using WebQRCode.Data;
using WebQRCode.Data.Entities.Identity;

namespace WebQRCode.Extensions;

public static class DbSeeder
{
    public static async Task SeedData(this WebApplication webApplication)
    {
        using var scope = webApplication.Services.CreateScope();
        //Цей об'єкт буде верта посилання на конткетс, який зараєстрвоано в Progran.cs
        var context = scope.ServiceProvider.GetRequiredService<QRCodeDbContext>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<RoleEntity>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();

        context.Database.Migrate();

        if (!context.Roles.Any())
        {
            foreach (var roleName in Roles.ListRoles())
            {
                await roleManager.CreateAsync(new RoleEntity { Name = roleName });
            }
        }
    }
}
