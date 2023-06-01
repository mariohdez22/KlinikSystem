using Microsoft.AspNetCore.Mvc;

namespace KlinikSystem.Controllers
{
    public class InicioPacientesController : Controller
    {
        public IActionResult IndexSitio()
        {
            return View();
        }
    }
}
