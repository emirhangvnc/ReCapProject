using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.Brand_Name).MinimumLength(2).WithMessage("Marka İsimmi En Az 2 Karakter Olmalıdır");
            RuleFor(b => b.Brand_Name).MaximumLength(30).WithMessage("Marka Adı En Fazla 30 Karakter Olabilir");
            RuleFor(b => b.Brand_Name).NotEmpty();
        }
    }
}
