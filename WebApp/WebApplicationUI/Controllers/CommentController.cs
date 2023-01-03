using Microsoft.AspNetCore.Mvc;

namespace WebApplicationUI.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult Partial_AddComment()
        {
            return PartialView();
        }
        public PartialViewResult Partial_CommentList()
        {
            return PartialView();
        }
    }
}
