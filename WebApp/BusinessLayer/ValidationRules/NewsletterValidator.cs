using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class NewsletterValidator :AbstractValidator<Newsletter>
    {
        public NewsletterValidator()
        {
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir eposta adresi giriniz.");
        }
    }
}
