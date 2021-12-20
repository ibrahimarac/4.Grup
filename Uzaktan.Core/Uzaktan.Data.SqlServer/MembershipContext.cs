using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Uzaktan.Data.SqlServer
{
    public class MembershipContext:IdentityDbContext<IdentityUser,IdentityRole,string>
    {
        public MembershipContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=UsersDB;Integrated Security=true");
        }
    }
}
