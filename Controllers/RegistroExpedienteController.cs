using KlinikSystem.Models;
using KlinikSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KlinikSystem.Recursos;
#pragma warning disable

namespace KlinikSystem.Controllers
{
    public class RegistroExpedienteController : Controller
    {
        public readonly KlinikSystemContext _baseDatos;

        public RegistroExpedienteController(KlinikSystemContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        public async Task<IActionResult> IndexRegistroExpediente(string buscar)
        {
            var registroExpediente = await _baseDatos.RegistroExpedientes
                           .Include(at => at.IdexpedienteNavigation)
                           
                           .ToListAsync();

            if (!String.IsNullOrEmpty(buscar))
            {
                registroExpediente = await _baseDatos.RegistroExpedientes.Where(

                    rg => rg.MotivoVisita!.Contains(buscar) ||
                         rg.Sintomas !.Contains(buscar) ||
                         rg.GravedadAsunto!.Contains(buscar) 

                    ).ToListAsync();
            }

            ViewData["RegistroExpedientes"] = new SelectList(_baseDatos.RegistroExpedientes, "Idexpediente", "RegistroExpediente");
            

            return View(registroExpediente);
        }

        [HttpGet]
        public IActionResult FiltroRegistroExpediente(int indice)
        {

            var registroExpediente = _baseDatos.RegistroExpedientes
                           .Where(i => i.Idexpediente == indice)
                           .Include(at => at.IdexpedienteNavigation)
                           
                           .Select(a => new
                           {
                               a.IdregistroExpediente,
                               a.MotivoVisita,
                               a.Sintomas,
                               a.GravedadAsunto,
                               a.Fecha,
                               RegistroExpediente = a.IdexpedienteNavigation.NumeroExpediente

                           })
                           .ToList();

            if (registroExpediente.Count == 0)
            {
                return Json(new { success = false, message = "No se encontraron datos para el area proporcionada" });
            }
            else
            {
                return Json(new { success = true, datos = registroExpediente });
            }

        }


        //-------------------------------------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> AgregarRegistroExpediente(int IDregistroexpediente)
        {
            RegistroExpedienteVM resgistroExpediente = new RegistroExpedienteVM()
            {
                obRegistroExpediente = new RegistroExpediente(),
                listaRegistroExpediente = await _baseDatos.Expedientes.Select(at => new SelectListItem()
                {
                    Text = at.NumeroExpediente,
                    Value = at.Idexpediente.ToString()

                }).ToListAsync(),

            };
            if (IDregistroexpediente != 0)
            {
                resgistroExpediente.obRegistroExpediente = await _baseDatos.RegistroExpedientes.FindAsync(IDregistroexpediente);
            }

            return View(resgistroExpediente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarRegistroExpediente(RegistroExpedienteVM registroExpediente)
        {
            if (ModelState.IsValid)
            {
                if (registroExpediente.obRegistroExpediente.Idexpediente == 0)
                {
                    
                    _baseDatos.RegistroExpedientes.Add(registroExpediente.obRegistroExpediente);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeCrear"] = "El usuario se agrego correctamente";
                    return RedirectToAction(nameof(AgregarRegistroExpediente));
                }
                else
                {
                   
                    _baseDatos.RegistroExpedientes.Update(registroExpediente.obRegistroExpediente);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeActualizar"] = "El usuario se actualizo correctamente";
                    return RedirectToAction(nameof(IndexRegistroExpediente));
                }
            }

            TempData["Error"] = "¡Advertencia! Campos vacios";

            registroExpediente = new RegistroExpedienteVM()
            {
                obRegistroExpediente = new RegistroExpediente(),
                listaRegistroExpediente = await _baseDatos.Expedientes.Select(at => new SelectListItem()
                {
                    Text = at.NumeroExpediente,
                    Value = at.Idexpediente.ToString()

                }).ToListAsync()
            };

            return View(registroExpediente);
        }




    }
}
