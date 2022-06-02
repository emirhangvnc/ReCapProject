using Business.Constants;
using Entities.DTOs.ModelDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.ModelValidator
{
    public class ModelDeleteDtoValidator : AbstractValidator<ModelDeleteDto>
    {
        public ModelDeleteDtoValidator()
        {
            RuleFor(m => m.Id).NotEmpty().WithMessage($"Model Id {Messages.NotEmpty}");
        }
    }
}
