using Business.Constants;
using Entities.DTOs.BrandDto;
using FluentValidation;


namespace Business.ValidationRules.FluentValidation.BrandValidator
{
    public class BrandUpdateDtoValidator : AbstractValidator<BrandUpdateDto>
    {
        public BrandUpdateDtoValidator()
        {
            RuleFor(b => b.Id).NotEmpty().WithMessage($"Marka Id {Messages.NotEmpty}");
            RuleFor(b => b.Name).NotEmpty().WithMessage($"Marka İsim {Messages.NotEmpty}");
            RuleFor(b => b.Name).MaximumLength(30).WithMessage($"Marka İsmi{Messages.Max30Caracter}");
        }
    }
}
