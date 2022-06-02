using Business.Constants;
using Entities.DTOs.CustomerDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CustomerValidator
{
    public class CustomerDeleteDtoValidator : AbstractValidator<CustomerDeleteDto>
    {
        public CustomerDeleteDtoValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage($"Müşteri Id {Messages.NotEmpty}");
        }
    }
}