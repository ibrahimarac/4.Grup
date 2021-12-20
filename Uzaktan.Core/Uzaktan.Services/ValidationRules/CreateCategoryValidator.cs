using FluentValidation;
using System.Linq;
using Uzaktan.Core.Domain.Dto.Category;
using Uzaktan.Core.Utilities.Extensions;

namespace Uzaktan.Services.ValidationRules
{
    public class CreateCategoryValidator:AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Kategori adı boş bırakılamaz")
                .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olabilir.")
                .MinimumLength(2).WithMessage("Kategori adı en az 2 karakter olabilir.")
                .Must(catName => !catName.IntersectWith('/', '*', '\'', '"' ))
                .WithMessage("Kategori adı /,*,' veya \" karakterini taşıyamaz.");
        }
    }
}
