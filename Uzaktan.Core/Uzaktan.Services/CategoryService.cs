using AutoMapper;
using System.Collections.Generic;
using Uzaktan.Core.Domain.Dto;
using Uzaktan.Core.Domain.Entites;
using Uzaktan.Core.Mappers;
using Uzaktan.Core.Repositories;
using Uzaktan.Core.Service;
using Uzaktan.Data.SqlServer.Repositories;

namespace Uzaktan.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryService()
        {
            _categoryRepo = new CategoryRepository();
            _mapper = new Mapper(new MapperConfiguration(
                cfg => cfg.AddProfile(new CategoryMapper())
             ));
        }

        public CategoryDto AddCategory(CategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<CategoryDto, Category>(categoryDto);
            var result= _categoryRepo.AddCategory(categoryEntity);
            if(result)
            {
                return _mapper.Map<Category, CategoryDto>(categoryEntity);
            }
            return null;
        }

        public bool DeleteCategory(int categoryId)
        {
            bool result= _categoryRepo.DeleteCategory(categoryId);
            return result;
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            IEnumerable<Category> categoryEntities = _categoryRepo.GetAllCategories();
            var categoryDtos = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categoryEntities);
            return categoryDtos;
        }

        public bool UpdateCategory(CategoryDto categoryDto)
        {
            var categoryEntity = _categoryRepo.GetById(categoryDto.Id);
            _mapper.Map(categoryDto,categoryEntity);
            bool result=_categoryRepo.UpdateCategory(categoryEntity);
            return result;
        }
    }
}
