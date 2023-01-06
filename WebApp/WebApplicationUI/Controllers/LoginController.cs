using Microsoft.AspNetCore.Mvc;

namespace WebApplicationUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
