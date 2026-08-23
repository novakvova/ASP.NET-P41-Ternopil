using WebQRCode.Data.Entities.Identity;

namespace WebQRCode.Interfaces;

public interface IJwtTokenService
{
    Task<string> CreateTokenAsync(UserEntity user);
}
