using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplicationUI.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CommentManager cm = new CommentManager(new EfCommentRepository());
        NewsletterManager nm = new NewsletterManager(new EfNewsletterRepository());

        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.CommentId = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }

        [HttpPost]
        public JsonResult AddComment(Comment p)
        {
            p.CommentDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
            p.CommentStatus = true;
            p.CommentImg = "/web/images/t1.jpg";
            cm.TAdd(p);
            var jsonComment = JsonConvert.SerializeObject(p);
            return Json(jsonComment);
        }

        public JsonResult CommentList(int id)
        {
            var values = cm.GetList(id);
            var jsonComment = JsonConvert.SerializeObject(values);
            return Json(jsonComment);
        }

        [HttpPost]
        public JsonResult SubscribeMail(Newsletter p)
        {
            NewsletterValidator validationRules = new NewsletterValidator();
            ValidationResult result = validationRules.Validate(p);

            if (result.IsValid)
            {
                p.MailStatus = true;
                nm.TAdd(p);
                var jsonNewsletter = JsonConvert.SerializeObject(p);
                return Json(jsonNewsletter);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return Json(null);
        }
    }
}
