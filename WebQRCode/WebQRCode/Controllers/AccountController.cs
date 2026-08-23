using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebQRCode.Data.Entities.Identity;
using WebQRCode.Interfaces;
using WebQRCode.Models.Account;

namespace WebQRCode.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController(IJwtTokenService jwtTokenService,
    UserManager<UserEntity> userManager) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var user = await userManager.FindByEmailAsync(model.Email);
        if(user!=null && await userManager.CheckPasswordAsync(user, model.Password))
        {
            var token = await jwtTokenService.CreateTokenAsync(user);
            return Ok(new { Token = token });
        }
        return Unauthorized("Не вірно вказані дані");
    }
}
