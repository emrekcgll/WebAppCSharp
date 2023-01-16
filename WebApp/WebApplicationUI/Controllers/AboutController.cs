using Microsoft.AspNetCore.Mvc;

namespace WebApplicationUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
