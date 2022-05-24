using Business.Constants;
using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage("İsim En Az 2 Karakter Olmalıdır");
            RuleFor(u => u.FirstName).MaximumLength(50).WithMessage(Messages.Max50Caracter);
            RuleFor(u => u.FirstName).NotEmpty().WithMessage($"İsim {Messages.NotEmpty}");

            RuleFor(u => u.LastName).MinimumLength(2).WithMessage("Soy İism En az 2 Karakter Olmalıdır");
            RuleFor(u => u.LastName).MaximumLength(50).WithMessage(Messages.Max50Caracter);
            RuleFor(u => u.LastName).NotEmpty().WithMessage($"Soy İsim {Messages.NotEmpty}");

            RuleFor(u => u.GenderId).NotEmpty().WithMessage($"Cinsiyet {Messages.NotEmpty}");
            RuleFor(u => u.Email).NotEmpty().WithMessage($"Email {Messages.NotEmpty}");
        }
    }
}
