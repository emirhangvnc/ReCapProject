using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(f => f.ColorName).MinimumLength(2).WithMessage("Yakıt Türü En Az 2 Karakter Olmalıdır");
            RuleFor(f => f.ColorName).MaximumLength(25).WithMessage("Yakıt Türü En Fazla 25 Karakter Olabilir");
            RuleFor(f => f.ColorName).NotEmpty();
        }
    }
}
