using Microsoft.AspNetCore.Mvc;

namespace KlinikSystem.Controllers
{
    public class LaboratoriosController : Controller
    {
        public IActionResult IndexLaboratorio()
        {
            return View();
        }
    }
}
