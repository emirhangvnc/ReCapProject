using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class FuelTypeValidator : AbstractValidator<FuelType>
    {
        public FuelTypeValidator()
        {
            RuleFor(f => f.FuelType_Name).MinimumLength(2).WithMessage("Yakıt Türü En Az 2 Karakter Olmalıdır");
            RuleFor(f => f.FuelType_Name).MaximumLength(20).WithMessage("Yakıt Türü En Fazla 20 Karakter Olabilir");
            RuleFor(f => f.FuelType_Name).NotEmpty();
        }
    }
}
