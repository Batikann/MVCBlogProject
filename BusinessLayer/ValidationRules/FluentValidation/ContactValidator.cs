using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("Soyisim Alanı Boş Geçilemez");
            RuleFor(c => c.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez");
            RuleFor(c => c.Message).NotEmpty().WithMessage("Mesaj Alanı Boş Geçilemez");
            RuleFor(c => c.Subject).NotEmpty().WithMessage("Konu Alanı Boş Geçilemez");
        }
    }
}
