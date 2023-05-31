using KlinikSystem.Models;
using KlinikSystem.Models.ViewModels;
using KlinikSystem.Recursos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KlinikSystem.Controllers
{
    public class PacientesController : Controller
    {
        public readonly KlinikSystemContext _baseDatos;

        public PacientesController(KlinikSystemContext baseDatos)
        {
            _baseDatos = baseDatos;
        }
        public async Task<IActionResult> IndexPacientes(string buscar)
        {
            var paciente = await _baseDatos.Pacientes
                           .Include(ep => ep.IdestadoPacienteNavigation)
                           .ToListAsync();

            if (!String.IsNullOrEmpty(buscar))
            {
                paciente = await _baseDatos.Pacientes.Where(

                    b => b.Nombre!.Contains(buscar) ||
                         b.Dui!.Contains(buscar) ||
                         b.Celular!.Contains(buscar) ||
                         b.Correo!.Contains(buscar)

                    ).ToListAsync();
            }


            ViewData["EstadoPaciente"] = new SelectList(_baseDatos.EstadoPacientes, "IdestadoPaciente", "EstadoPaciente");


            return View(paciente);
        }
        [HttpGet]
        public IActionResult FiltroEstado(int indice)
        {

            var paciente = _baseDatos.Pacientes
                           .Where(i => i.IdestadoPaciente == indice)
                           .Include(ep => ep.IdestadoPacienteNavigation)
                           .Select(a => new
                           {
                               a.Idpaciente,
                               a.Nombre,
                               a.Dui,
                               a.Correo,
                               a.Celular,
                               a.FechaNacimiento,
                               EstadoPaciente = a.IdestadoPacienteNavigation.EstadoPaciente1
                           })
                           .ToList();

            if (paciente.Count == 0)
            {
                return Json(new { success = false, message = "No se encontraron datos para el estado proporcionado" });
            }
            else
            {
                return Json(new { success = true, datos = paciente });
            }

        }
        [HttpGet]
        public async Task<IActionResult> AgregarPaciente(int IDpaciente)
        {
            PacienteVM paciente = new PacienteVM()
            {
                obPaciente = new Paciente(),
                listaEstadoPaciente = await _baseDatos.EstadoPacientes.Select(ep => new SelectListItem()
                {
                    Text = ep.EstadoPaciente1,
                    Value = ep.IdestadoPaciente.ToString()

                }).ToListAsync(),
                
            };

            if (IDpaciente != 0)
            {
                paciente.obPaciente = await _baseDatos.Pacientes.FindAsync(IDpaciente);
            }

            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarPaciente(PacienteVM paciente)
        {
            if (ModelState.IsValid)
            {
                if (paciente.obPaciente.IdestadoPaciente == 0)
                {
                    paciente.obPaciente.Contrasena = Utilidades.EncriptarClave(paciente.obPaciente.Contrasena);
                    _baseDatos.Pacientes.Add(paciente.obPaciente);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeCrear"] = "El usuario se agrego correctamente";
                    return RedirectToAction(nameof(AgregarPaciente));
                }
                else
                {
                    paciente.obPaciente.Contrasena = Utilidades.EncriptarClave(paciente.obPaciente.Contrasena);
                    _baseDatos.Pacientes.Update(paciente.obPaciente);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeActualizar"] = "El usuario se actualizo correctamente";
                    return RedirectToAction(nameof(IndexPacientes));
                }
            }

            TempData["Error"] = "¡Advertencia! Campos vacios";

            paciente = new PacienteVM()
            {
                obPaciente = new Paciente(),
                listaEstadoPaciente = await _baseDatos.EstadoPacientes.Select(ep => new SelectListItem()
                {
                    Text = ep.EstadoPaciente1,
                    Value = ep.IdestadoPaciente.ToString()

                }).ToListAsync()
            };

            return View(paciente);
        }
    }
}
