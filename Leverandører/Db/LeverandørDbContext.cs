using Microsoft.EntityFrameworkCore;

namespace Leverandører.Db
{
    public class LeverandørDbContext : DbContext
    {
        public DbSet<Leverandør> Leverandør { get; set; }
        public LeverandørDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}