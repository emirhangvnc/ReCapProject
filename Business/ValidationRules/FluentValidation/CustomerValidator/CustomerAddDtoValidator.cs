using Business.Constants;
using Entities.DTOs.CustomerDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CustomerValidator
{
    public class CustomerAddDtoValidator : AbstractValidator<CustomerAddDto>
    {
        public CustomerAddDtoValidator()
        {
            RuleFor(r => r.UserId).NotEmpty().WithMessage($"Kullanıcı {Messages.NotEmpty}");
            RuleFor(r => r.CompanyName).NotEmpty().WithMessage($"Şirket İsim {Messages.NotEmpty}");
            RuleFor(r => r.CompanyName).MaximumLength(50).WithMessage($"Şirket İsim {Messages.Max50Caracter}");
        }
    }
}

