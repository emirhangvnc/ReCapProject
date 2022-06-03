using Business.Constants;
using Entities.DTOs.CarImageDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CarImageValidator
{
    public class CarImageUpdateDtoValidator : AbstractValidator<CarImageUpdateDto>
    {
        public CarImageUpdateDtoValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage($"Resim Id {Messages.NotEmpty}");
            RuleFor(c => c.CarId).NotEmpty().WithMessage($"Araba Boş Geçilemez {Messages.NotEmpty}");
        }
    }
}
