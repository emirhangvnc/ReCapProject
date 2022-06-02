using Business.Constants;
using Entities.DTOs.CustomerDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CustomerValidator
{
    public class CustomerUpdateDtoValidator : AbstractValidator<CustomerUpdateDto>
    {
        public CustomerUpdateDtoValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage($"Müşteri Id {Messages.NotEmpty}");
            RuleFor(c => c.UserId).NotEmpty().WithMessage($"Kullanıcı Id {Messages.NotEmpty}");
            RuleFor(c => c.CompanyName).NotEmpty().WithMessage($"Şirket İsim {Messages.NotEmpty}");
        }
    }
}