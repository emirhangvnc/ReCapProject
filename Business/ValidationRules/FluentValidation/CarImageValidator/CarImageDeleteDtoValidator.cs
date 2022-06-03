using Business.Constants;
using Entities.DTOs.CarImageDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CarImageValidator
{
    public class CarImageDeleteDtoValidator : AbstractValidator<CarImageDeleteDto>
    {
        public CarImageDeleteDtoValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage($"Resim Id {Messages.NotEmpty}");
        }
    }
}