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
        }
    }
}
