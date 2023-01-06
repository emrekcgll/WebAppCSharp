using Microsoft.AspNetCore.Mvc;

namespace WebApplicationUI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error(int code)
        {
            return View();
        }
    }
}
