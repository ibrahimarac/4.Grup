using System.Collections.Generic;
using Uzaktan.Core.Domain.Dto.Category;
using Uzaktan.Core.Utilities.Results;

namespace Uzaktan.Core.Service
{
    public interface ICategoryService
    {
        IResult AddCategory(CreateCategoryDto categoryDto);
        IResult DeleteCategory(int categoryId);
        IResult UpdateCategory(CategoryDto categoryDto);
        IResult GetAllCategories();
        IResult GetCategoryById(int id);
    }
}
