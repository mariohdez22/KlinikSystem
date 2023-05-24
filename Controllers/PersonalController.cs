using KlinikSystem.Models;
using KlinikSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
#pragma warning disable

namespace KlinikSystem.Controllers
{
    public class PersonalController : Controller
    {
        public readonly KlinikSystemContext _baseDatos;

        public PersonalController(KlinikSystemContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        public async Task<IActionResult> IndexPersonal(string buscar)
        {
            var personal = await _baseDatos.Personals
                           .Include(at => at.IdareaTrabajoNavigation)
                           .Include(e => e.IdespecialidadNavigation)
                           .Include(ep => ep.IdestadoPersonalNavigation)
                           .ToListAsync();

            if (!String.IsNullOrEmpty(buscar))
            {
                personal = await _baseDatos.Personals.Where(
                    
                    b => b.Nombres!.Contains(buscar) ||
                         b.Dui!.Contains(buscar) ||
                         b.Profecion!.Contains(buscar) ||
                         b.Celular!.Contains(buscar) ||
                         b.Correo!.Contains(buscar)

                    ).ToListAsync();
            }

            ViewData["AreaTrabajo"] = new SelectList(_baseDatos.AreaTrabajos, "IdareaTrabajo", "AreaTrabajo1");
            ViewData["EstadoPersonal"] = new SelectList(_baseDatos.EstadoPersonals, "IdestadoPersonal", "EstadoPersonal1");
            ViewData["Especialidades"] = new SelectList(_baseDatos.Especialidades, "Idespecialidad", "Especialidad");

            return View(personal);
        }

        [HttpGet]
        public IActionResult FiltroArea(int indice)
        {

            var personal = _baseDatos.Personals
                           .Where(i => i.IdareaTrabajo == indice)
                           .Include(at => at.IdareaTrabajoNavigation)
                           .Include(e => e.IdespecialidadNavigation)
                           .Include(ep => ep.IdestadoPersonalNavigation)
                           .Select(a => new
                           {
                               a.Idpersonal,
                               a.Nombres,
                               a.Profecion,
                               a.Dui,
                               a.Celular,
                               a.Correo,
                               a.Imagen,
                               AreaTrabajo = a.IdareaTrabajoNavigation.AreaTrabajo1,
                               Especialidad = a.IdespecialidadNavigation.Especialidad,
                               EstadoPersonal = a.IdestadoPersonalNavigation.EstadoPersonal1
                           })
                           .ToList();

            if(personal.Count == 0)
            {
               return Json(new { success = false, message = "No se encontraron datos para el area proporcionada" });
            }
            else
            {
               return Json(new { success = true, datos = personal });
            }

        }

        [HttpGet]
        public IActionResult FiltroEspecialidad(int indice)
        {

            var personal = _baseDatos.Personals
                           .Where(i => i.Idespecialidad == indice)
                           .Include(at => at.IdareaTrabajoNavigation)
                           .Include(e => e.IdespecialidadNavigation)
                           .Include(ep => ep.IdestadoPersonalNavigation)
                           .Select(a => new
                           {
                               a.Idpersonal,
                               a.Nombres,
                               a.Profecion,
                               a.Dui,
                               a.Celular,
                               a.Correo,
                               a.Imagen,
                               AreaTrabajo = a.IdareaTrabajoNavigation.AreaTrabajo1,
                               Especialidad = a.IdespecialidadNavigation.Especialidad,
                               EstadoPersonal = a.IdestadoPersonalNavigation.EstadoPersonal1
                           })
                           .ToList();

            if (personal.Count == 0)
            {
                return Json(new { success = false, message = "No se encontraron datos para la especialidad proporcionada" });
            }
            else
            {
                return Json(new { success = true, datos = personal });
            }

        }

        [HttpGet]
        public IActionResult FiltroEstado(int indice)
        {

            var personal = _baseDatos.Personals
                           .Where(i => i.IdestadoPersonal == indice)
                           .Include(at => at.IdareaTrabajoNavigation)
                           .Include(e => e.IdespecialidadNavigation)
                           .Include(ep => ep.IdestadoPersonalNavigation)
                           .Select(a => new
                           {
                               a.Idpersonal,
                               a.Nombres,
                               a.Profecion,
                               a.Dui,
                               a.Celular,
                               a.Correo,
                               a.Imagen,
                               AreaTrabajo = a.IdareaTrabajoNavigation.AreaTrabajo1,
                               Especialidad = a.IdespecialidadNavigation.Especialidad,
                               EstadoPersonal = a.IdestadoPersonalNavigation.EstadoPersonal1
                           })
                           .ToList();

            if (personal.Count == 0)
            {
                return Json(new { success = false, message = "No se encontraron datos para el estado proporcionado" });
            }
            else
            {
                return Json(new { success = true, datos = personal });
            }

        }

        //-------------------------------------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> AgregarPersonal(int IDpersonal) 
        {
            PersonalVM personal = new PersonalVM()
            {
                obPersonal = new Personal(),
                listaAreaTrabajo = await _baseDatos.AreaTrabajos.Select(at => new SelectListItem() 
                { 
                    Text = at.AreaTrabajo1,
                    Value = at.IdareaTrabajo.ToString()

                }).ToListAsync(),
                listaEspecialidad = await _baseDatos.Especialidades.Select(e => new SelectListItem() 
                { 
                
                    Text = e.Especialidad,
                    Value = e.Idespecialidad.ToString()

                }).ToListAsync(),
                listaEstadoPersonal = await _baseDatos.EstadoPersonals.Select(ep => new SelectListItem() 
                { 
                    Text = ep.EstadoPersonal1,
                    Value = ep.IdestadoPersonal.ToString()

                }).ToListAsync()
            };

            if (IDpersonal != 0)
            {
                personal.obPersonal = await _baseDatos.Personals.FindAsync(IDpersonal);
            }

            return View(personal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarPersonal(PersonalVM personal)
        {
            if (ModelState.IsValid)
            {
                if (personal.obPersonal.Idpersonal == 0)
                {
                    _baseDatos.Personals.Add(personal.obPersonal);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeCrear"] = "El usuario se agrego correctamente";
                    return RedirectToAction(nameof(AgregarPersonal));
                }
                else
                {
                    _baseDatos.Personals.Update(personal.obPersonal);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeActualizar"] = "El usuario se actualizo correctamente";
                    return RedirectToAction(nameof(IndexPersonal));
                }
            }

            TempData["Error"] = "¡Advertencia! Campos vacios";

            personal = new PersonalVM()
            {
                obPersonal = new Personal(),
                listaAreaTrabajo = await _baseDatos.AreaTrabajos.Select(at => new SelectListItem()
                {
                    Text = at.AreaTrabajo1,
                    Value = at.IdareaTrabajo.ToString()

                }).ToListAsync(),
                listaEspecialidad = await _baseDatos.Especialidades.Select(e => new SelectListItem()
                {

                    Text = e.Especialidad,
                    Value = e.Idespecialidad.ToString()

                }).ToListAsync(),
                listaEstadoPersonal = await _baseDatos.EstadoPersonals.Select(ep => new SelectListItem()
                {
                    Text = ep.EstadoPersonal1,
                    Value = ep.IdestadoPersonal.ToString()

                }).ToListAsync()
            };

            return View(personal);
        }

    }
}
