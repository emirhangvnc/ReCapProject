using Business.Constants;
using Entities.DTOs.RentalDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.RentalValidator
{
    public class RentalDeleteDtoValidator : AbstractValidator<RentalDeleteDto>
    {
        public RentalDeleteDtoValidator()
        {
            RuleFor(r => r.Id).NotEmpty().WithMessage($"Kiralama Id {Messages.NotEmpty}");
        }
    }
}

