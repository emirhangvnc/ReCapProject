using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class GenderValidator : AbstractValidator<Gender>
    {
        public GenderValidator()
        {
            RuleFor(g => g.Gender_Name).MinimumLength(2).WithMessage("Cinsiyet En Az 2 Karakter Olmalıdır");
            RuleFor(g => g.Gender_Name).MaximumLength(15).WithMessage("Cinsiyet En Fazla 15 Karakter Olabilir");
            RuleFor(g => g.Gender_Name).NotEmpty();
        }
    }
}
