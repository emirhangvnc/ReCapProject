using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarTypeDetailValidator : AbstractValidator<CarTypeDetail>
    {
        public CarTypeDetailValidator()
        {
            RuleFor(f => f.Category_Id).NotEmpty();
            RuleFor(f => f.FuelType_Id).NotEmpty();
        }
    }
}
