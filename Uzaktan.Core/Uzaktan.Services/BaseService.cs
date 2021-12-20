using FluentValidation;
using Uzaktan.Core.Utilities.Results;

namespace Uzaktan.Services
{

    public abstract class BaseService
    {
        public IResult Validate<TValidator,TData>(TData dataForValidation) 
            where TValidator:AbstractValidator<TData>,new()
            
        {
            var validator = new TValidator();
            var validationResult = validator.Validate(dataForValidation);
            if (validationResult.IsValid)
                return new Result(true, "");
            else
                return new Result(false, validationResult.Errors[0].ErrorMessage);
        }
    }
}
