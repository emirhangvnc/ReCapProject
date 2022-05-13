using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(m =>m.Model_Name).MinimumLength(2).WithMessage("Model Adı En Az 2 Karakter Olmalıdır");
            RuleFor(m => m.Model_Name).MaximumLength(20).WithMessage("Model Adı En Fazla 20 Karakter Olabilir");
            RuleFor(m => m.Model_Name).NotEmpty();

            RuleFor(m => m.Brand_Id).NotEmpty();
            RuleFor(m => m.CarTypeDetail_Id).NotEmpty();

            RuleFor(m => m.Model_Year).NotEmpty();

            RuleFor(m => m.Daily_Price).GreaterThan(0);

        }
    }
}
