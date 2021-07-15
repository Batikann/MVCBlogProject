using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez.");
            RuleFor(c => c.CategoryName).MinimumLength(3).WithMessage("Kategori Adı 3 Karakterden Kısa Olamaz.");
            RuleFor(c => c.CategoryExplanation).MinimumLength(5).WithMessage("Kategori Açıklaması 3 Karakterden Kısa Olamaz.");
            RuleFor(c => c.CategoryExplanation).NotEmpty().WithMessage("Kategori Açıklaması Boş Geçilemez.");
        }
    }
}
