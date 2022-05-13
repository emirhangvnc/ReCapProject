using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarTypeDetailValidator : AbstractValidator<CarTypeDetail>
    {
        public CarTypeDetailValidator()
        {
            RuleFor(f => f.Category_Id).NotEmpty();
            RuleFor(f => f.FuelType_Id).NotEmpty();
        }
    }
}
