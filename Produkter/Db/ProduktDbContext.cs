using Microsoft.EntityFrameworkCore;

namespace Produkter.Db
{
    public class ProduktDbContext : DbContext
    {
        public DbSet<Produkt> Produkt { get; set; }
        public ProduktDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}