using Business.Constants;
using Entities.DTOs.FuelTypeDto;
using FluentValidation;

namespace Business.ValidationRules.FuelTypeValidator
{
    public class FuelTypeDeleteDtoValidator : AbstractValidator<FuelTypeDeleteDto>
    {
        public FuelTypeDeleteDtoValidator()
        {
            RuleFor(f => f.Id).NotEmpty().WithMessage($"Yakıt Tip Id {Messages.NotEmpty}");
        }
    }
}
