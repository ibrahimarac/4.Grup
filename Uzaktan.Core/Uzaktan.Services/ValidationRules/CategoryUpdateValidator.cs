using FluentValidation;
using Uzaktan.Core.Domain.Dto.Category;

namespace Uzaktan.Services.ValidationRules
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateRequestDto>
    {
        public CategoryUpdateValidator()
        {
            //CategoryDto için validation kurallarını yazalım.
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Kategori adı boş olamaz.")
                .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olabilir.");

        }
    }
}
