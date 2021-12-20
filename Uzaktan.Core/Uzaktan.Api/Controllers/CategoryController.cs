using Microsoft.AspNetCore.Mvc;
using Uzaktan.Core.Domain.Dto.Category;
using Uzaktan.Core.Service;
using Uzaktan.Services.ValidationRules;

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
            var result=_categoryService.GetAllCategories();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [Route("get/{id}")]
        [HttpGet]
        public IActionResult GetCategoryById(int id)
        {
            var result = _categoryService.GetCategoryById(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [Route("add")]
        [HttpPost]
        public IActionResult AddCategory(CreateCategoryDto category)
        {
            var result= _categoryService.AddCategory(category);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

<<<<<<< HEAD
        [Route("update/{id}")]
        [HttpPut]
        public IActionResult UpdateCategory([FromBody]CategoryUpdateRequestDto categoryDto,[FromRoute]int id)
        {            
            var result=_categoryService.UpdateCategory(categoryDto,id);
=======
        [Route("update")]
        [HttpPost]
        public IActionResult UpdateCategory(CategoryDto categoryDto)
        {            
            var result=_categoryService.UpdateCategory(categoryDto);
>>>>>>> 218d2fe05b357eafa4273f988f16f8c8ac457bf6
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [Route("delete/{id}")]
        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            var result = _categoryService.DeleteCategory(id);
            if (result.Success)
                return Ok();
            else
                return BadRequest();
        }

    }
}
