using Business.Constants;
using Entities.DTOs.ColorDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.ColorValidator
{
    public class ColorDeleteDtoValidator : AbstractValidator<ColorDeleteDto>
    {
        public ColorDeleteDtoValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage($"Renk Id {Messages.NotEmpty}");
        }
    }
}