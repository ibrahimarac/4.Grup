

using Microsoft.EntityFrameworkCore;
using Uzaktan.Core.Domain.Entites;

namespace Uzaktan.Data.InMemoryDatabase
{
    public class ShopContext:DbContext
    {
        public ShopContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("UzaktanDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
