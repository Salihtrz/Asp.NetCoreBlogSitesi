using EFLayer.Class;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRoles
{
    public class AdminUserValidationRoles : AbstractValidator<User>
    {
        public AdminUserValidationRoles()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Ad Boş geçilemez!");
            RuleFor(x => x.Name).Length(2, 50).WithMessage("Minimum 2 maksimum 50 karakter girilebilir.");
            RuleFor(x => x.SurName).NotNull().WithMessage("Soyad Boş geçilemez!");
            RuleFor(x => x.SurName).Length(2, 25).WithMessage("Minimum 2 maksimum 25 karakter girilebilir.");
            RuleFor(x => x.UserAdi).NotNull().WithMessage("Kullanıcı Adı Boş geçilemez!");
            RuleFor(x => x.UserAdi).Length(5, 50).WithMessage("Minimum 5 maksimum 50 karakter girilebilir.");
            RuleFor(x => x.Password).NotNull().WithMessage("Şifre Boş geçilemez!");
            RuleFor(x => x.Password).Length(8, 25).WithMessage("Minimum 8 maksimum 25 karakter girilebilir.");
        }
    }
}
