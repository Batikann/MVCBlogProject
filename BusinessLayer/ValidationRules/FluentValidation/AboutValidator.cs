using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(c => c.AboutContent1).NotEmpty().WithMessage("Hakkımızda Alanı Boş Geçilemez");
            RuleFor(c => c.AboutContent2).NotEmpty().WithMessage("Hakkımızda Alanı Boş Geçilemez");
            RuleFor(c => c.AboutContent2).MinimumLength(10).WithMessage("Hakkımızda Kısmı 10 Karakterden Kısa Olamaz");
            RuleFor(c => c.AboutContent1).MinimumLength(10).WithMessage("Hakkımızda Kısmı 10 Karakterden Kısa Olamaz");
            RuleFor(c => c.AboutContent1).MaximumLength(200).WithMessage("Hakkımızda Kısmı 200 Karakterden Uzun Olamaz");
            RuleFor(c => c.AboutContent2).MaximumLength(200).WithMessage("Hakkımızda Kısmı 200 Karakterden Uzun Olamaz");
        }
    }
}
