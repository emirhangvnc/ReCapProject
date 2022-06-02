using Business.Constants;
using Entities.DTOs.ModelDto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.ModelValidator
{
    public class ModelUpdateDtoValidator : AbstractValidator<ModelUpdateDto>
    {
        public ModelUpdateDtoValidator()
        {
            RuleFor(m => m.Id).NotEmpty().WithMessage($"Model Id {Messages.NotEmpty}");
            RuleFor(m => m.BrandId).NotEmpty().WithMessage($"Marka İsim {Messages.NotEmpty}");
            RuleFor(m => m.CarTypeDetailId).NotEmpty().WithMessage($"Araba Tipi {Messages.NotEmpty}");
            RuleFor(m => m.ColorId).NotEmpty().WithMessage($"Renk {Messages.NotEmpty}");
            RuleFor(m => m.DailyPrice).NotEmpty().WithMessage($"Günlük Fiyat {Messages.NotEmpty}");
            RuleFor(m => m.Description).NotEmpty().WithMessage($"Açıklama {Messages.NotEmpty}");
            RuleFor(m => m.Description).MaximumLength(100).WithMessage($"Açıklama {Messages.Max50Caracter}");
            RuleFor(m => m.ModelName).NotEmpty().WithMessage($"Model İsim {Messages.NotEmpty}");
            RuleFor(m => m.ModelName).MaximumLength(50).WithMessage($"Model İsim {Messages.Max50Caracter}");
            RuleFor(m => m.ModelYear).NotEmpty().WithMessage($"Model Yıl {Messages.NotEmpty}");
        }
    }
}
