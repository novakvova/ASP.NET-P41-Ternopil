using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebQRCode.Data.Entities;
using WebQRCode.Data.Entities.Identity;

namespace WebQRCode.Data;

public class QRCodeDbContext : IdentityDbContext<UserEntity, RoleEntity, int>
{
    public QRCodeDbContext(DbContextOptions<QRCodeDbContext> options)
    : base(options)
    { }

    //Список QrCodes користувача
    public DbSet<QrCodeEntity> QrCodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //identity
        modelBuilder.Entity<UserRoleEntity>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRoleEntity>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);
    }
}
