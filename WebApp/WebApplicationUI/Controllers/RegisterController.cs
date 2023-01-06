using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationUI.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer p)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                ViewBag.Message = "Yazar kaydı başarıyla gerçekleştirildi.";
                ViewBag.Message2 = "Yazar kaydı gerçekleştirilemedi";
                p.WriterStatus = true;
                p.WriterAbout = "Test Kayıt";
                p.WriterImage = "Test Görsel";
                //if (p.WriterPassword != p.WriterConfirmPassword)
                //{
                //    ModelState.AddModelError("WriterConfirmPassword", "Girilen şifreler eşleşmiyor.");
                //    return View(p);
                //}
                wm.TAdd(p);
                return View();
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
