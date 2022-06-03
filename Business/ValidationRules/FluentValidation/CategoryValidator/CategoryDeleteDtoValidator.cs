using Business.Constants;
using Entities.DTOs.CategoryDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CategoryValidator
{
    public class CategoryDeleteDtoValidator : AbstractValidator<CategoryDeleteDto>
    {
        public CategoryDeleteDtoValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage($"Category Id {Messages.NotEmpty}");
        }
    }
}
