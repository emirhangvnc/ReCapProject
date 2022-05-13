using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(f => f.Color_Name).MinimumLength(2).WithMessage("Yakıt Türü En Az 2 Karakter Olmalıdır");
            RuleFor(f => f.Color_Name).MaximumLength(25).WithMessage("Yakıt Türü En Fazla 25 Karakter Olabilir");
            RuleFor(f => f.Color_Name).NotEmpty();
        }
    }
}
