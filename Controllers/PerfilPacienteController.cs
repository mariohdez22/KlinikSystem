using Microsoft.AspNetCore.Mvc;

namespace KlinikSystem.Controllers
{
    public class PerfilPacienteController : Controller
    {
        public IActionResult IndexPerfil()
        {
            return View();
        }

        //------------------------------------------------------------------------------

        public IActionResult IndexCitas()
        {
            return View();
        }

        public IActionResult AgregarCita() 
        {
            return View();
        }

        //------------------------------------------------------------------------------

        public IActionResult IndexRecetas()
        {
            return View();
        }

    }
}
