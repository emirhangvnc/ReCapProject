using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.BrandName).MaximumLength(30).WithMessage("Marka Adı En Fazla 30 Karakter Olabilir");
            RuleFor(b => b.BrandName).NotEmpty();
        }
    }
}
