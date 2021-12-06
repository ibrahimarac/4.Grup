
using Microsoft.EntityFrameworkCore;
using Uzaktan.Core.Domain.Entites;

namespace Uzaktan.Data.SqlServer
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
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=UzaktanDB;Integrated Security=true");
        }
    }
}
