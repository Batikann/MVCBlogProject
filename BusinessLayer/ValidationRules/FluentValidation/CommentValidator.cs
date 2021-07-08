using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CommentValidator:AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(c => c.Mail).NotEmpty().WithMessage("Eposta Alanı Boş Geçilemez");
            RuleFor(c => c.UserName).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
            RuleFor(c => c.UserName).MinimumLength(5).WithMessage("İsim Alanı 5 Karakterden Kısa Olamaz");
            RuleFor(c => c.UserName).MinimumLength(10).WithMessage("İsim Alanı 10 Karakterden Uzun Olamaz");
            RuleFor(c => c.CommentText).NotEmpty().WithMessage("Mesaj Alanı Boş Geçilemez");
            RuleFor(c => c.CommentText).MaximumLength(200).WithMessage("Mesaj Alanı 200 Karakterden Uzun Olamaz");
        }
    }
}
