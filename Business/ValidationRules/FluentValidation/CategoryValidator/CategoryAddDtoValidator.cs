using Business.Constants;
using Entities.DTOs.CategoryDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CategoryValidator
{
    public class CategoryAddDtoValidator : AbstractValidator<CategoryAddDto>
    {
        public CategoryAddDtoValidator()
        {
            RuleFor(c => c.Name).MaximumLength(30).WithMessage($"Category İsimi {Messages.Max30Caracter}");
            RuleFor(c => c.Name).NotEmpty().WithMessage($"Category İsim {Messages.NotEmpty}");
        }
    }
}
