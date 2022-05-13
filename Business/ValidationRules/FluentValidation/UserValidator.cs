﻿using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage("İsim En Az 2 Karakter Olmalıdır");
            RuleFor(u => u.FirstName).Length(2,25).WithMessage("En Fazla 25 Karakter Olabilir");
            RuleFor(u => u.FirstName).NotEmpty();

            RuleFor(u => u.LastName).MinimumLength(2).WithMessage("Soy İism En az 2 Karakter Olmalıdır");
            RuleFor(u => u.LastName).Length(2, 25).WithMessage("En Fazla 25 Karakter Olabilir Soy İsim");
            RuleFor(u => u.LastName).NotEmpty();

            RuleFor(u => u.Password).MinimumLength(4).WithMessage("En Az 4 Karakterli Bir Şifre Girinzi");

            RuleFor(u => u.Gender_Id).NotEmpty();
        }
    }
}