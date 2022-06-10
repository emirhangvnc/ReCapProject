using Business.Constants;
using Entities.DTOs.BrandDto;
using FluentValidation;


namespace Business.ValidationRules.FluentValidation.BrandValidator
{
    public class BrandUpdateDtoValidator : AbstractValidator<BrandUpdateDto>
    {
        public BrandUpdateDtoValidator()
        {
            RuleFor(b => b.BrandId).NotEmpty().WithMessage($"Marka Id {Messages.NotEmpty}");
            RuleFor(b => b.BrandName).NotEmpty().WithMessage($"Marka İsim {Messages.NotEmpty}");
            RuleFor(b => b.BrandName).MaximumLength(30).WithMessage($"Marka İsmi{Messages.Max30Caracter}");
        }
    }
}
