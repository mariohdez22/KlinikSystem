using KlinikSystem.Models;
using KlinikSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KlinikSystem.Recursos;
using System.Linq;
using NuGet.Protocol;
#pragma warning disable

namespace KlinikSystem.Controllers
{
    public class ExpedienteController : Controller
    {

        public readonly KlinikSystemContext _baseDatos;

        public ExpedienteController(KlinikSystemContext baseDatos)
        {
            _baseDatos = baseDatos;
        }
        public async Task<IActionResult> IndexExpediente (String buscar)
        {
            var expediente = await _baseDatos.Expedientes
                .Include(at => at.IdestadoExpedienteNavigation)
                .Include(e => e.IdpersonalNavigation)
                .Include(ep => ep.IdpacienteNavigation)
                .ToListAsync(); 
            
            if (!String.IsNullOrEmpty(buscar))
            { 
            expediente = await _baseDatos.Expedientes.Where(
                c => c.NumeroExpediente!.Contains(buscar) ||
                c.Alergias!.Contains(buscar)
                ).ToListAsync();
            }

            ViewData["EstadoExpediente"] = new SelectList(_baseDatos.EstadoExpedientes, "IdestadoExpediente", "EstadoExpediente1");
            ViewData["Pacientes"] = new SelectList(_baseDatos.Pacientes, "Idpaciente", "Nombre");
            ViewData["Personal"] = new SelectList(_baseDatos.Personals, "Idpersonal", "Nombres");

            return View(expediente);
        }

        [HttpGet]
        public IActionResult FiltroEstadoExpediente(int indice) 
        {
            var expediente =  _baseDatos.Expedientes
                .Where(i => i.IdestadoExpediente == indice)
                .Include(at => at.IdestadoExpediente)
                .Include(e => e.Idpersonal)
                .Include(ep => ep.Idpaciente)
                .Select(pa => new
                {
                    pa.Idexpediente,
                    pa.NumeroExpediente,
                    pa.FechaCreacion,
                    pa.Alergias,
                    EstadoExpediente = pa.IdestadoExpedienteNavigation.EstadoExpediente1,
                    Pacientes = pa.IdpacienteNavigation.Nombre,
                    Personal = pa.IdpersonalNavigation.Nombres
                })
                .ToList();
            if (expediente.Count == 0)
            {
                return Json(new { success = false, message = "No se encontraron datos para el area proporcionada" });
            }
            else
            {
                return Json(new { success = true, datos = expediente });
            }

        }

        [HttpGet]
        public IActionResult FiltroExpPersonal(int indice)
        {
            var expediente = _baseDatos.Expedientes
                .Where(i => i.IdestadoExpediente == indice)
                .Include(at => at.IdestadoExpediente)
                .Include(e => e.Idpersonal)
                .Include(ep => ep.Idpaciente)
                .Select(pa => new
                {
                    pa.Idexpediente,
                    pa.NumeroExpediente,
                    pa.FechaCreacion,
                    pa.Alergias,
                    EstadoExpediente = pa.IdestadoExpedienteNavigation.EstadoExpediente1,
                    Pacientes = pa.IdpacienteNavigation.Nombre,
                    Personal = pa.IdpersonalNavigation.Nombres
                })
                .ToList();
            if (expediente.Count == 0)
            {
                return Json(new { success = false, message = "No se encontraron datos para el area proporcionada" });
            }
            else
            {
                return Json(new { success = true, datos = expediente });
            }

        }
        //-------------------------------------------------------------------------------


        [HttpGet]
        public async Task<IActionResult> AgregarExpediente(int IDexpediente)
        {
            ExpedienteVM expediente = new ExpedienteVM()
            {
                obExpediente = new Expediente(),
                listaEstadoExpediente = await _baseDatos.EstadoExpedientes.Select(at => new SelectListItem()
                {
                    Text = at.EstadoExpediente1,
                    Value = at.IdestadoExpediente.ToString()

                }).ToListAsync(),
                listaPaciente = await _baseDatos.Pacientes.Select(at => new SelectListItem()
                {
                    Text = at.Nombre,
                    Value = at.Idpaciente.ToString()

                }).ToListAsync(),
                listaPersonal = await _baseDatos.Personals.Select(at => new SelectListItem()
                {
                    Text = at.Nombres,
                    Value = at.Idpersonal.ToString()

                }).ToListAsync()
            };

            if (IDexpediente != 0)
            {
                expediente.obExpediente = await _baseDatos.Expedientes.FindAsync(IDexpediente);
            }

            return View(expediente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarExpediente(ExpedienteVM expediente)
        {
            if (ModelState.IsValid)
            {
                if (expediente.obExpediente.Idexpediente == 0)
                {
                    
                    _baseDatos.Expedientes.Add(expediente.obExpediente);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeCrear"] = "El expediente se agrego correctamente";
                    return RedirectToAction(nameof(AgregarExpediente));
                }
                else
                {
                    
                    _baseDatos.Expedientes.Update(expediente.obExpediente);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeActualizar"] = "El usuario se actualizo correctamente";
                    return RedirectToAction(nameof(IndexExpediente));
                }

            }

            TempData["Error"] = "¡Advertencia! Campos vacios";

            expediente = new ExpedienteVM()
            {
                obExpediente = new Expediente(),
                listaEstadoExpediente = await _baseDatos.EstadoExpedientes.Select(at => new SelectListItem()
                {
                    Text = at.EstadoExpediente1,
                    Value = at.IdestadoExpediente.ToString()

                }).ToListAsync(),
                listaPaciente = await _baseDatos.Pacientes.Select(at => new SelectListItem()
                {
                    Text = at.Nombre,
                    Value = at.Idpaciente.ToString()

                }).ToListAsync(),
                listaPersonal = await _baseDatos.Personals.Select(at => new SelectListItem()
                {
                    Text = at.Nombres,
                    Value = at.Idpersonal.ToString()

                }).ToListAsync()

            };

            return View(expediente);
        }

    }
}
