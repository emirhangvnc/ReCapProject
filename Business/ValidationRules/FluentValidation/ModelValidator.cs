using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(m =>m.ModelName).MinimumLength(2).WithMessage($"Model İsim {Messages.Min2Caracter}");
            RuleFor(m => m.ModelName).MaximumLength(50).WithMessage($"Model İsmi {Messages.Max50Caracter}");
            RuleFor(m => m.ModelName).NotEmpty();

            RuleFor(m => m.BrandId).NotEmpty().WithMessage($"Marka {Messages.NotEmpty}");
            RuleFor(m => m.CarTypeDetailId).NotEmpty().WithMessage($"Arabanın Tip {Messages.NotEmpty}");
            RuleFor(m => m.ModelYear).NotEmpty().WithMessage($"Yıl {Messages.NotEmpty}");

            RuleFor(m => m.DailyPrice).GreaterThan(0);

        }
    }
}
