using System;
using Uzaktan.Core.Domain.Entites;
using Uzaktan.Data.SqlServer;

namespace Uzaktan.UI.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ShopContext ctx=new ShopContext())
            {
                var category = new Category
                {
                    Name="Kategori 1",
                    IsActive=true
                };
                ctx.Categories.Add(category);
                ctx.SaveChanges();
            }
            Console.WriteLine("UzaktanShop veritabanı oluşturuldu ve içerisine bir adet kategori eklendi.");

            Console.ReadKey();
        }
    }
}
