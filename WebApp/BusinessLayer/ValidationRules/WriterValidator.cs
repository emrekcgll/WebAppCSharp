using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş bırakılamaz").MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz.").MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz.");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz.").NotEmpty().WithMessage("Mail adresi boş bırakılamaz.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş bırakılamaz.");
            RuleFor(x => x.WriterConfirmPassword).NotEmpty().WithMessage("Şifre boş bırakılamaz.");
            RuleFor(x => x.WriterPassword).Equal(x => x.WriterConfirmPassword).WithMessage("Şifreler eşleşmiyor.");


        }
    }
}
