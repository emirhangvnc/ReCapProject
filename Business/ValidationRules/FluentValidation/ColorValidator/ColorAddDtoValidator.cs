using Business.Constants;
using Entities.DTOs.ColorDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.ColorValidator
{
    public class ColorAddDtoValidator : AbstractValidator<ColorAddDto>
    {
        public ColorAddDtoValidator()
        {
            RuleFor(c => c.Name).MaximumLength(30).WithMessage($"Renk İsim {Messages.Max30Caracter}");
            RuleFor(c => c.Name).NotEmpty().WithMessage($"Renk İsim{Messages.NotEmpty}");
        }
    }
}
