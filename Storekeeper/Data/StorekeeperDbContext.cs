using Microsoft.EntityFrameworkCore;
using Storekeeper.Models;

namespace Storekeeper.Data
{
    public class StorekeeperDbContext : DbContext
    {
        public StorekeeperDbContext(DbContextOptions<StorekeeperDbContext> options) : base(options)
        {
        }

        public DbSet<Storehouse> Storehouses { get; set; }
        public DbSet<ProductNomenclature> ProductNomenclatures { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
