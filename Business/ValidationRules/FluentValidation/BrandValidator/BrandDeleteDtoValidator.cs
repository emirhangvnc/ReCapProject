using Business.Constants;
using Entities.DTOs.BrandDto;
using FluentValidation;


namespace Business.ValidationRules.FluentValidation.BrandValidator
{
    public class BrandDeleteDtoValidator : AbstractValidator<BrandDeleteDto>
    {
        public BrandDeleteDtoValidator()
        {
            RuleFor(b => b.Id).NotEmpty().WithMessage($"Marka Id {Messages.NotEmpty}");
        }
    }
}
