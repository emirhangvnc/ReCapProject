using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(f => f.ColorName).MinimumLength(2).WithMessage($"Renk İsim {Messages.Min2Caracter}");
            RuleFor(f => f.ColorName).MaximumLength(30).WithMessage($"Renk İsim {Messages.Max30Caracter}");
            RuleFor(f => f.ColorName).NotEmpty().WithMessage($"Renk İsim{Messages.NotEmpty}");
        }
    }
}
