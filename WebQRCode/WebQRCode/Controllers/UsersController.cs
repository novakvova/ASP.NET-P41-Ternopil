using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQRCode.Data;
using WebQRCode.Models.Users;

namespace WebQRCode.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(QRCodeDbContext qrDbContext) 
    : ControllerBase
{
    [HttpGet] //Метод буде повертати json на GET Request
    public async Task<IActionResult> GetUsers()
    {
        var users = await qrDbContext.Users
            .Select(x => new UserItemModel
            {
                Id = x.Id,
                FullName = $"{x.LastName} {x.FirstName}",
                Email = x.Email,
                Image = x.Image
            }).ToListAsync();

        return Ok(users);
    }
}
