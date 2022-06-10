using Business.Constants;
using Entities.DTOs.CarTypeDetailDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CarTypeDetailValidator
{
    public class CarTypeDetailAddDtoValidator : AbstractValidator<CarTypeDetailAddDto>
    {
        public CarTypeDetailAddDtoValidator()
        {
            RuleFor(c => c.CategoryId).NotEmpty().WithMessage($"Categori {Messages.NotEmpty}");
            RuleFor(c => c.FuelTypeId).NotEmpty().WithMessage($"Yakıt Tip {Messages.NotEmpty}");
        }
    }
}
