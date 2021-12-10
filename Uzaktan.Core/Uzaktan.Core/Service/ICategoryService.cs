using System;
using System.Collections.Generic;
using System.Text;
using Uzaktan.Core.Domain.Dto;

namespace Uzaktan.Core.Service
{
    public interface ICategoryService
    {
        CategoryDto AddCategory(CategoryDto categoryDto);
        bool DeleteCategory(int categoryId);
        bool UpdateCategory(CategoryDto categoryDto);
        IEnumerable<CategoryDto> GetAllCategories();
    }
}
