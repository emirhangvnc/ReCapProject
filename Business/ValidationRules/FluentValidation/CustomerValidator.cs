using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Company_Name).MinimumLength(2).WithMessage("Müşteri İsmi En Az 2 Karakter Olmalıdır");
            RuleFor(c => c.Company_Name).MaximumLength(40).WithMessage("Müşteri İsmi En Fazla 25 Karakter Olabilir");
            RuleFor(c => c.Company_Name).NotEmpty();
            RuleFor(c => c.User_Id).NotEmpty();
        }
    }
}
