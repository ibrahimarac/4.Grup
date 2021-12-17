using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Uzaktan.Core.Domain.Dto.Category;
using Uzaktan.Core.Domain.Entites;
using Uzaktan.Core.Repositories;
using Uzaktan.Core.Service;
using Uzaktan.Core.Utilities.Results;
using Uzaktan.Services.ValidationRules;

namespace Uzaktan.Services
{
    //AOP

    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        
        public IResult AddCategory(CreateCategoryDto categoryDto)
        {
            var validatorResult = Validate<CreateCategoryValidator, CreateCategoryDto>(categoryDto);
            if (!validatorResult.Success)
                return validatorResult;

            var categoryEntity = _mapper.Map<CreateCategoryDto, Category>(categoryDto);
            try
            {
                _categoryRepo.AddCategory(categoryEntity);
                var categoryInDbDto = _mapper.Map<Category, CategoryDto>(categoryEntity);
                return new DataResult<CategoryDto>(true, "Kategori başarıyla eklendi.", categoryInDbDto);
            }
            catch (Exception ex)
            {
                return new DataResult<CategoryDto>(false, ex.InnerException!=null?ex.InnerException.Message: ex.Message, null);
            }
        }

        public IResult DeleteCategory(int categoryId)
        {
            try
            {
                _categoryRepo.DeleteCategory(categoryId);
                return new Result(true, $"{categoryId} numaralı kategori başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return new Result(false, $"{categoryId} numaralı kategori silinirken <{ex.Message}> hatası oluştu.");
            }
        }

        public IResult GetAllCategories()
        {
            var categoryEntities = _categoryRepo.GetAllCategories();
            var categoryDtos = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categoryEntities);
            if (categoryDtos.Any())
                return new DataResult<IEnumerable<CategoryDto>>(true, "", categoryDtos);
            else
                return new DataResult<IEnumerable<CategoryDto>>(false, "Kayıtlı kategori bulunamadı.", null);
        }

        public IResult GetCategoryById(int id)
        {
            var categoryEntity = _categoryRepo.GetById(id);
            var categoryDto= _mapper.Map<Category, CategoryDto>(categoryEntity);
            if (categoryDto == null)
                return new DataResult<CategoryDto>(false, $"{id} numaralı bir kategori bulunamadı.", null);
            else
                return new DataResult<CategoryDto>(true, "", categoryDto);
        }

        public IResult UpdateCategory(CategoryDto categoryDto)
        {
            var validatorResult = Validate<CategoryValidator, CategoryDto>(categoryDto);
            if (!validatorResult.Success)
                return validatorResult;

            var categoryEntity = _categoryRepo.GetById(categoryDto.Id);
            _mapper.Map(categoryDto, categoryEntity);
            try
            {
                _categoryRepo.UpdateCategory(categoryEntity);
                return new Result(true, "Kategori başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }            
        }
    }
}
