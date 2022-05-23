using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate.Date).NotEmpty().WithMessage("Tarih Giriniz");
            RuleFor(r => r.CustomerId).NotEmpty().WithMessage("Müşteri Giriniz");
            RuleFor(r => r.ModelId).NotEmpty().WithMessage("Model Giriniz");
        }
    }
}
