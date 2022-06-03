using Business.Constants;
using Entities.DTOs.CarImageDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CarImageValidator
{
    public class CarImageAddDtoValidator : AbstractValidator<CarImageAddDto>
    {
        public CarImageAddDtoValidator()
        {
            RuleFor(c => c.CarId).NotEmpty().WithMessage($"Araba Boş Geçilemez {Messages.NotEmpty}");
        }
    }
}
