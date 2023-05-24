using Microsoft.AspNetCore.Mvc;

namespace KlinikSystem.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult IndexLogin()
        {
            return View();
        }
    }
}
