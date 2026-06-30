using Microsoft.EntityFrameworkCore;

namespace WebHike.Data;

public class HikeDbContext : DbContext
{
    public HikeDbContext(DbContextOptions<HikeDbContext> options)
        : base(options)
    {  }
}
