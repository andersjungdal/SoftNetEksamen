using Microsoft.EntityFrameworkCore;

namespace Kategorier.Db
{
    public class KategoriDbContext : DbContext
    {
        public DbSet<Kategori> Kategori { get; set; }
        public KategoriDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}