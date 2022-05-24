using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarTypeDetailValidator : AbstractValidator<CarTypeDetail>
    {
        public CarTypeDetailValidator()
        {
            RuleFor(f => f.CategoryId).NotEmpty().WithMessage($"Categori {Messages.NotEmpty}");
            RuleFor(f => f.FuelTypeId).NotEmpty().WithMessage($"Yakıt Tip {Messages.NotEmpty}");
        }
    }
}
