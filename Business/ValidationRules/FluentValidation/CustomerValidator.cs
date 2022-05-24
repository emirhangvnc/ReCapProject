using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CompanyName).MinimumLength(2).WithMessage($"Şirket İsim {Messages.Min2Caracter}");
            RuleFor(c => c.CompanyName).MaximumLength(50).WithMessage($"Şirket İsim {Messages.Max50Caracter}");
            RuleFor(c => c.CompanyName).NotEmpty().WithMessage($"Şirket İsim {Messages.NotEmpty}");
            RuleFor(c => c.UserId).NotEmpty().WithMessage($"Kullanıcı {Messages.NotEmpty}");
        }
    }
}
