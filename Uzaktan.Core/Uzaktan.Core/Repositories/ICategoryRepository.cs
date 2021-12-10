using System;
using System.Collections.Generic;
using System.Text;
using Uzaktan.Core.Domain.Entites;

namespace Uzaktan.Core.Repositories
{
    public interface ICategoryRepository
    {
        bool AddCategory(Category category);
        bool DeleteCategory(int id);
        bool UpdateCategory(Category category);
        IEnumerable<Category> GetAllCategories();
        Category GetById(int id);
    }
}
