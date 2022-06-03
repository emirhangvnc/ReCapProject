using Business.Constants;
using Entities.DTOs.FuelTypeDto;
using FluentValidation;

namespace Business.ValidationRules.FuelTypeValidator
{
    public class FuelTypeUpdateDtoValidator : AbstractValidator<FuelTypeUpdateDto>
    {
        public FuelTypeUpdateDtoValidator()
        {
            RuleFor(f => f.Id).NotEmpty().WithMessage($"Yakıt Tip Id {Messages.NotEmpty}");
            RuleFor(f => f.Name).NotEmpty().WithMessage($"Yakıt Tip İsim {Messages.NotEmpty}");
            RuleFor(f => f.Name).MaximumLength(30).WithMessage($"Yakıt Tip {Messages.Max30Caracter}");
        }
    }
}