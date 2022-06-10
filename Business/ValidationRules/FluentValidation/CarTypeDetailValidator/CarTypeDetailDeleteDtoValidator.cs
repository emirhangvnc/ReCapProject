using Business.Constants;
using Entities.DTOs.CarTypeDetailDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CarTypeDetailValidator
{
    public class CarTypeDetailDeleteDtoValidator : AbstractValidator<CarTypeDetailDeleteDto>
    {
        public CarTypeDetailDeleteDtoValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage($"Id {Messages.NotEmpty}");
        }
    }
}
