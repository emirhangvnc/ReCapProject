using Business.Constants;
using Entities.DTOs.CarTypeDetailDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CarTypeDetailValidator
{
    public class CarTypeDetailUpdateDtoValidator : AbstractValidator<CarTypeDetailUpdateDto>
    {
        public CarTypeDetailUpdateDtoValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage($"ID {Messages.NotEmpty}");
            RuleFor(c => c.CategoryId).NotEmpty().WithMessage($"Categori {Messages.NotEmpty}");
            RuleFor(c => c.FuelTypeId).NotEmpty().WithMessage($"Yakıt Tip {Messages.NotEmpty}");
        }
    }
}

