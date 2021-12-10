using System;
using Uzaktan.Core.Domain.Entites;
using Uzaktan.Core.Repositories;
using Uzaktan.Data.InMemoryDatabase.Repositories;

namespace Uzaktan.UI.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var category = new Category
            {
                Name = "Kategori 4",
                IsActive = true
            };

            ICategoryRepository categoryRepo = new CategoryRepository();
            categoryRepo.AddCategory(category);

            Console.WriteLine("UzaktanShop veritabanı oluşturuldu ve içerisine bir adet kategori eklendi.");

            var categories = categoryRepo.GetAllCategories();

            foreach (var cat in categories)
            {
                Console.WriteLine($"{cat.Id} {cat.Name}");
            }

            Console.ReadKey();
        }
    }
}
