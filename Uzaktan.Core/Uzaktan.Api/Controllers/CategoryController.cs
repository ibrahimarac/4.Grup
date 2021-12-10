using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Uzaktan.Core.Domain.Dto;
using Uzaktan.Core.Service;

namespace Uzaktan.Api.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("get")]
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            IEnumerable<CategoryDto> categories= _categoryService.GetAllCategories();
            return Ok(categories);
        }

    }
}
