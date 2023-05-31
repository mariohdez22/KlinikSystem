using KlinikSystem.Models.ViewModels;
using KlinikSystem.Models;
using KlinikSystem.Recursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KlinikSystem.Controllers
{
    public class CitasController : Controller
    {
        private readonly KlinikSystemContext _baseDatos;

        public CitasController(KlinikSystemContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        public async Task<IActionResult> IndexCitas(string buscar)
        {
            var citas = await _baseDatos.Citas
                           .Include(at => at.IdestadoCitaNavigation)
                           .Include(e => e.IdmetodoPagoNavigation)
                           .Include(ep => ep.IdpacienteNavigation)
                           .Include(er => er.IdpersonalNavigation)
                           .ToListAsync();

            if (!String.IsNullOrEmpty(buscar))
            {
                citas = await _baseDatos.Citas.Where(

                    b => b.NumCita!.Contains(buscar) ||
                         b.DuiPaciente!.Contains(buscar) ||
                         b.EspecialidadPersonal!.Contains(buscar) 

                    ).ToListAsync();
            }

            ViewData["EstadoCita"] = new SelectList(_baseDatos.EstadoCita, "IdestadoCita", "EstadoCita");
            ViewData["MetodoPago"] = new SelectList(_baseDatos.MetodoPagos, "IdmetodoPago", "MetodoPago1");
            ViewData["Paciente"] = new SelectList(_baseDatos.Pacientes, "Idpaciente", "Nombre");
            ViewData["Personal"] = new SelectList(_baseDatos.Personals, "Idpersonal", "Nombres");

            return View(citas);
        }

        [HttpGet]
        public IActionResult FiltroEstado(int indice)
        {

            var citas = _baseDatos.Citas
                           .Where(i => i.IdestadoCita == indice)
                           .Include(at => at.IdestadoCitaNavigation)
                           .Include(e => e.IdmetodoPagoNavigation)
                           .Include(ep => ep.IdpacienteNavigation)
                           .Include(er => er.IdpersonalNavigation)
                           .Select(a => new
                           {
                               a.Idcitas,
                               a.NumCita,
                               a.Fecha,
                               a.EspecialidadPersonal,
                               a.Precio,
                               EstadoCita = a.IdestadoCitaNavigation.EstadoCita,
                               MetodoPago = a.IdmetodoPagoNavigation.MetodoPago1,
                               Paciente = a.IdpacienteNavigation.Nombre,
                               Personal = a.IdpersonalNavigation.Nombres,
                           })
                           .ToList();

            if (citas.Count == 0)
            {
                return Json(new { success = false, message = "No se encontraron datos para el estado proporcionada" });
            }
            else
            {
                return Json(new { success = true, datos = citas });
            }

        }

        [HttpGet]
        public IActionResult FiltroMetodo(int indice)
        {

            var citas = _baseDatos.Citas
                           .Where(i => i.IdestadoCita == indice)
                           .Include(at => at.IdestadoCitaNavigation)
                           .Include(e => e.IdmetodoPagoNavigation)
                           .Include(ep => ep.IdpacienteNavigation)
                           .Include(er => er.IdpersonalNavigation)
                           .Select(a => new
                           {
                               a.Idcitas,
                               a.NumCita,
                               a.Fecha,
                               a.EspecialidadPersonal,
                               a.Precio,
                               EstadoCita = a.IdestadoCitaNavigation.EstadoCita,
                               Paciente = a.IdpacienteNavigation.Nombre,
                               Personal = a.IdpersonalNavigation.Nombres,
                           })
                           .ToList();

            if (citas.Count == 0)
            {
                return Json(new { success = false, message = "No se encontraron datos para el pago proporcionada" });
            }
            else
            {
                return Json(new { success = true, datos = citas });
            }

        }

        [HttpGet]
        public IActionResult FiltroPaciente(int indice)
        {

            var citas = _baseDatos.Citas
                           .Where(i => i.IdestadoCita == indice)
                           .Include(at => at.IdestadoCitaNavigation)
                           .Include(e => e.IdmetodoPagoNavigation)
                           .Include(ep => ep.IdpacienteNavigation)
                           .Include(er => er.IdpersonalNavigation)
                           .Select(a => new
                           {
                               a.Idcitas,
                               a.NumCita,
                               a.Fecha,
                               a.EspecialidadPersonal,
                               a.Precio,
                               EstadoCita = a.IdestadoCitaNavigation.EstadoCita,
                               MetodoPago = a.IdmetodoPagoNavigation.MetodoPago1,
                               Paciente = a.IdpacienteNavigation.Nombre,
                               Personal = a.IdpersonalNavigation.Nombres,
                           })
                           .ToList();

            if (citas.Count == 0)
            {
                return Json(new { success = false, message = "No se encontraron datos para el paciente proporcionada" });
            }
            else
            {
                return Json(new { success = true, datos = citas });
            }

        }
        [HttpGet]
        public IActionResult FiltroPersonal(int indice)
        {

            var citas = _baseDatos.Citas
                           .Where(i => i.IdestadoCita == indice)
                           .Include(at => at.IdestadoCitaNavigation)
                           .Include(e => e.IdmetodoPagoNavigation)
                           .Include(ep => ep.IdpacienteNavigation)
                           .Include(er => er.IdpersonalNavigation)
                           .Select(a => new
                           {
                               a.Idcitas,
                               a.NumCita,
                               a.Fecha,
                               a.EspecialidadPersonal,
                               a.Precio,
                               EstadoCita = a.IdestadoCitaNavigation.EstadoCita,
                               MetodoPago = a.IdmetodoPagoNavigation.MetodoPago1,
                               Paciente = a.IdpacienteNavigation.Nombre,
                               Personal = a.IdpersonalNavigation.Nombres,
                           })
                           .ToList();

            if (citas.Count == 0)
            {
                return Json(new { success = false, message = "No se encontraron datos para el personal proporcionada" });
            }
            else
            {
                return Json(new { success = true, datos = citas });
            }

        }

        //-------------------------------------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> AgregarCita(int IDcita)
        {
            CitasVM citas = new CitasVM()
            {
                obCitas = new Cita(),
                listaEstadoCitas = await _baseDatos.EstadoCita.Select(at => new SelectListItem()
                {
                    Text = at.EstadoCita,
                    Value = at.IdestadoCita.ToString()

                }).ToListAsync(),
                listaMetodoPago = await _baseDatos.MetodoPagos.Select(e => new SelectListItem()
                {

                    Text = e.MetodoPago1,
                    Value = e.IdmetodoPago.ToString()

                }).ToListAsync(),
                listaPaciente = await _baseDatos.Pacientes.Select(ep => new SelectListItem()
                {
                    Text = ep.Nombre,
                    Value = ep.Idpaciente.ToString()

                }).ToListAsync(),
                listaPersonal = await _baseDatos.Personals.Select(er => new SelectListItem()
                {
                    Text = er.Nombres,
                    Value = er.Idpersonal.ToString()

                }).ToListAsync()
            };

            if (IDcita != 0)
            {
                citas.obCitas = await _baseDatos.Citas.FindAsync(IDcita);
            }

            return View(citas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarCita(CitasVM citas)
        {
            if (ModelState.IsValid)
            {
                if (citas.obCitas.Idcitas == 0)
                {
                    
                    _baseDatos.Citas.Add(citas.obCitas);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeCrear"] = "La cita se agrego correctamente";
                    return RedirectToAction(nameof(AgregarCita));
                }
                else
                {
                    
                    _baseDatos.Citas.Update(citas.obCitas);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeActualizar"] = "La cita se actualizo correctamente";
                    return RedirectToAction(nameof(IndexCitas));
                }
            }

            TempData["Error"] = "¡Advertencia! Campos vacios";

            citas = new CitasVM()
            {
                obCitas = new Cita(),
                listaEstadoCitas = await _baseDatos.EstadoCita.Select(at => new SelectListItem()
                {
                    Text = at.EstadoCita,
                    Value = at.IdestadoCita.ToString()

                }).ToListAsync(),
                listaMetodoPago = await _baseDatos.MetodoPagos.Select(e => new SelectListItem()
                {

                    Text = e.MetodoPago1,
                    Value = e.IdmetodoPago.ToString()

                }).ToListAsync(),
                listaPaciente = await _baseDatos.Pacientes.Select(ep => new SelectListItem()
                {
                    Text = ep.Nombre,
                    Value = ep.Idpaciente.ToString()

                }).ToListAsync(),
                listaPersonal = await _baseDatos.Personals.Select(er => new SelectListItem()
                {
                    Text = er.Nombres,
                    Value = er.Idpersonal.ToString()

                }).ToListAsync()
            };

            return View(citas);
        }

    }
}