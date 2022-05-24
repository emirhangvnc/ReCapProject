using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.BrandName).MaximumLength(30).WithMessage($"Marka İsmi{Messages.Max30Caracter}");
            RuleFor(b => b.BrandName).NotEmpty().WithMessage($"Marak İsim {Messages.NotEmpty}");
        }
    }
}
