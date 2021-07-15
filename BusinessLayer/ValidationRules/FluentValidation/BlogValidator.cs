using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(c => c.BlogTitle).NotEmpty().WithMessage("Blog Başlığı Boş Geçilemez.");
            RuleFor(c => c.BlogTitle).MinimumLength(2).WithMessage("Blog Başlığı 2 Karakterden Kısa Olamaz.");
            RuleFor(c => c.BlogImage).NotEmpty().WithMessage("Resim Seçmelisiniz.");
            RuleFor(c => c.BlogContent).NotEmpty().WithMessage("Blog İçerik Alanı Boş Bırakılamaz.");
            RuleFor(c => c.BlogPreRead).NotEmpty().WithMessage("Blog Ön Okuma Alanı Boş Bırakılamaz.");
            RuleFor(c => c.BlogPreRead).MinimumLength(10).WithMessage("Blog Ön Okuma Alanı 10 Karakterden Kısa Olamaz.");
            RuleFor(c => c.BlogPreRead).MaximumLength(30).WithMessage("Blog Ön Okuma Alanı 30 Karakterden Uzun Olamaz.");
        }
    }
}
