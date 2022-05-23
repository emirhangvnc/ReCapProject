using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(m =>m.ModelName).MinimumLength(2).WithMessage("Model Adı En Az 2 Karakter Olmalıdır");
            RuleFor(m => m.ModelName).MaximumLength(20).WithMessage("Model Adı En Fazla 20 Karakter Olabilir");
            RuleFor(m => m.ModelName).NotEmpty();

            RuleFor(m => m.BrandId).NotEmpty();
            RuleFor(m => m.CarTypeDetailId).NotEmpty();

            RuleFor(m => m.ModelYear).NotEmpty();

            RuleFor(m => m.DailyPrice).GreaterThan(0);

        }
    }
}
