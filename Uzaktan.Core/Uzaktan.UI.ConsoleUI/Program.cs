using System;
using Uzaktan.Core.Domain.Dto;
using Uzaktan.Core.Domain.Entites;
using Uzaktan.Core.Repositories;
using Uzaktan.Core.Service;
using Uzaktan.Data.InMemoryDatabase.Repositories;
using Uzaktan.Services;

namespace Uzaktan.UI.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var category = new CategoryDto
            {
                Name = "Kategori 4",
                IsActive = true
            };

            ICategoryService categoryService = new CategoryService();
            categoryService.AddCategory(category);

            Console.WriteLine("UzaktanShop veritabanı oluşturuldu ve içerisine bir adet kategori eklendi.");

            var categories = categoryService.GetAllCategories();

            foreach (var cat in categories)
            {
                Console.WriteLine($"{cat.Id} {cat.Name}");
            }

            Console.ReadKey();
        }
    }
}
