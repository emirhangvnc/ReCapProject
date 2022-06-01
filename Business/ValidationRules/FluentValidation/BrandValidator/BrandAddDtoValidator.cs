using Business.Constants;
using Entities.DTOs.BrandDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.BrandValidator
{
    public class BrandAddDtoValidator : AbstractValidator<BrandAddDto>
    {
        public BrandAddDtoValidator()
        {
            RuleFor(b => b.Name).MaximumLength(30).WithMessage($"Marka İsmi{Messages.Max30Caracter}");
            RuleFor(b => b.Name).NotEmpty().WithMessage($"Marka İsim {Messages.NotEmpty}");
        }
    }
}
