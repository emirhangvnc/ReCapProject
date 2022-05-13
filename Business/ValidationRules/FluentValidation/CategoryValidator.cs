using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(f => f.Category_Name).MaximumLength(25).WithMessage("Categori İsmi En Fazla 25 Karakter Olabilir");
            RuleFor(f => f.Category_Name).NotEmpty();
        }
    }
}
