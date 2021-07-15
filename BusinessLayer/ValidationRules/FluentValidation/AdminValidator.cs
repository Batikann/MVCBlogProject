using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class AdminValidator:AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(c => c.UserName).NotEmpty().WithMessage("Kullanıcı Adı Alanı Boş Geçilemez.");
            RuleFor(c => c.UserName).MinimumLength(5).WithMessage("Kullanıcı Adı 5 Karakterden Kısa Olamaz.");
            RuleFor(c => c.UserName).MaximumLength(15).WithMessage("Kullanıcı Adı 15 Karakterden Uzun Olamaz.");
            RuleFor(c => c.AdminMail).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez.");
            RuleFor(c => c.Password).NotEmpty().WithMessage("Şifre Alanı Boş Geçilemez");
            RuleFor(c => c.Password).MinimumLength(8).WithMessage("Şifre 8 Karakterden Kısa Olamaz");
            RuleFor(c => c.Password).MaximumLength(12).WithMessage("Şifre 12 Karakterden Uzun Olamaz");
            //RuleFor(c => c.AdminAbout).NotEmpty().WithMessage("Hakkında Kısmı Boş Geçilemez.");
            //RuleFor(c => c.AdminAbout).MinimumLength(10).WithMessage("Hakkında Kısmı 10 Karakterden Kısa Olamaz.");
            //RuleFor(c => c.AdminAbout).MaximumLength(30).WithMessage("Hakkında Kısmı 30 Karakterden Uzun Olamaz.");

        }
    }
}
