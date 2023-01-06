using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplicationUI.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CommentManager cm = new CommentManager(new EfCommentRepository());

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
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
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
    }
}
