using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(f => f.CategoryName).MaximumLength(30).WithMessage($"{Messages.Max30Caracter}");
            RuleFor(f => f.CategoryName).NotEmpty().WithMessage($"Categori İsim {Messages.NotEmpty}");
        }
    }
}
