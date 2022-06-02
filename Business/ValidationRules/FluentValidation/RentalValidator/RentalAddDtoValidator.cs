using Business.Constants;
using Entities.DTOs.RentalDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.RentalValidator
{
    public class RentalAddDtoValidator : AbstractValidator<RentalAddDto>
    {
        public RentalAddDtoValidator()
        {
            RuleFor(r => r.CustomerId).NotEmpty().WithMessage($"Müşteri {Messages.NotEmpty}");
            RuleFor(r => r.ModelId).NotEmpty().WithMessage($"Araba Model {Messages.NotEmpty}");
            RuleFor(r => r.RentDate).NotEmpty().WithMessage($"Kiralama Başlangıç {Messages.NotEmpty}");
            RuleFor(r => r.ReturnDate).NotEmpty().WithMessage($"Kiralama Bitiş {Messages.NotEmpty}");
        }
    }
}
