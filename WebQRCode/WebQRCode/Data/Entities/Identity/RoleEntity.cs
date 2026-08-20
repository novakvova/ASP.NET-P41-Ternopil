using Microsoft.AspNetCore.Identity;

namespace WebQRCode.Data.Entities.Identity;

public class RoleEntity : IdentityRole<int>
{
    public ICollection<UserRoleEntity>? UserRoles { get; set; }
}
