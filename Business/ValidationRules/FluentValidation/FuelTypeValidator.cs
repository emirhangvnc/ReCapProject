using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class FuelTypeValidator : AbstractValidator<FuelType>
    {
        public FuelTypeValidator()
        {
            RuleFor(f => f.FuelTypeName).MaximumLength(30).WithMessage($"Yakıt Türü {Messages.Max30Caracter}");
            RuleFor(f => f.FuelTypeName).NotEmpty().WithMessage($"Yakıt Türü {Messages.NotEmpty}");
        }
    }
}
