using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebQRCode.Data.Entities.Identity;
using WebQRCode.Interfaces;

namespace WebQRCode.Services;

public class JwtTokenService(IConfiguration configuration,
    UserManager<UserEntity> userManager) : IJwtTokenService
{
    public async Task<string> CreateTokenAsync(UserEntity user)
    {
        var key = configuration["Jwt:Key"];

        //claims - це дані, які записуються у token і зним передаються
        //Вони будуть доступні користувачу, який авторизувався.

        var claims = new List<Claim>
        {
            new Claim("email", user.Email)
            //Сюди можу додати будь-які іншу інформацію
        };
        foreach(var role in await userManager.GetRolesAsync(user))
        {
            claims.Add(new Claim("roles", role));
        }
        //ключ шифрування перетворюємо в байти
        var keyBytes = Encoding.UTF8.GetBytes(key);
        //робимо ключа
        var symmenticSecurityKey = new SymmetricSecurityKey(keyBytes);
        //Вказуємо ключ і алгоритм шифрування токена
        var signingCredentials = new SigningCredentials(
            symmenticSecurityKey,
            SecurityAlgorithms.HmacSha256);
        //робимо токен і вказуємо йому налаштування
        var jwtSecurityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: signingCredentials);
        //Робимо ключ у вигляді звичайного рядка тексту
        string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return token;
    }
}
