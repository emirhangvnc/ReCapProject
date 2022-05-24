using Business.Constants;
using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class GenderValidator : AbstractValidator<Gender>
    {
        public GenderValidator()
        {
            RuleFor(g => g.GenderName).MinimumLength(2).WithMessage($"Cinsiyet İsmi {Messages.Min2Caracter}");
            RuleFor(g => g.GenderName).MaximumLength(30).WithMessage($"Cinsiyet İsmi {Messages.Max30Caracter}");
            RuleFor(g => g.GenderName).NotEmpty().WithMessage($"Cinsiyet İsmi {Messages.NotEmpty}");
        }
    }
}
