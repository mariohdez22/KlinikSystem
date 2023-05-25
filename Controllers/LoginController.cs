using Microsoft.AspNetCore.Mvc;
using KlinikSystem.Servicios.Contrato;
using KlinikSystem.Recursos;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using KlinikSystem.Models;
#pragma warning disable

namespace KlinikSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioServices _PersonalServicio;

        public LoginController(IUsuarioServices PersonalServicio)
        {
            _PersonalServicio = PersonalServicio;            
        }

        [HttpGet]
        public IActionResult IndexLogin()
        {
            ClaimsPrincipal claimuser = HttpContext.User;
            string nombreUsuario = "";

            if (claimuser.Identity.IsAuthenticated)
            {
                nombreUsuario = claimuser.Claims.Where(c => c.Type == ClaimTypes.Name)
                    .Select(c => c.Value).SingleOrDefault();
            }

            ViewData["nombreUsuario"] = nombreUsuario;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexLogin(string correo, string clave)
        {
            Personal personalEncontrado = await _PersonalServicio.GetPersonal(correo, Utilidades.EncriptarClave(clave));

            List<AreaTrabajo> areaTrabajos = await _PersonalServicio.GetArea(personalEncontrado.Idpersonal);

            if (personalEncontrado == null) 
            {
                ViewData["Mensaje"] = "No se pudo encontrar el usuario";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, personalEncontrado.Nombres)
            };

            foreach (var tipos in areaTrabajos)
            {
                claims.Add(new Claim(ClaimTypes.Role, tipos.AreaTrabajo1));
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                              CookieAuthenticationDefaults.AuthenticationScheme,
                              new ClaimsPrincipal(claimsIdentity),
                              properties
                              );

            return RedirectToAction("IndexPersonal", "Personal");
        }
    }
}
