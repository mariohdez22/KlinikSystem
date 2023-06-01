using KlinikSystem.Models;
using KlinikSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
#pragma warning disable
namespace KlinikSystem.Controllers
{
    public class RecetasController : Controller
    {
        public readonly KlinikSystemContext _baseDatos;

        public RecetasController(KlinikSystemContext baseDatos)
        {
            _baseDatos = baseDatos;

        }
        public async Task<IActionResult> IndexReceta(String buscar)
        {
            var receta = await _baseDatos.Receta
                .Include(at => at.IdexpedienteNavigation)
                .ToListAsync();

            if (!String.IsNullOrEmpty(buscar))
            {
                receta = await _baseDatos.Receta.Where(
                    r => r.CodigoReceta!.Contains(buscar) ||
                    r.Medicamento!.Contains(buscar) ||
                    r.Indicaciones!.Contains(buscar) ||

                     r.DuracionTratamiento!.Contains(buscar)
                    ).ToListAsync();
            }

            ViewData["Receta"] = new SelectList(_baseDatos.Receta, "IdReceta", "receta1");
            ViewData["Expediente"] = new SelectList(_baseDatos.Expedientes, "IdExpediente", "Expediente1");

            return View(receta);
        }

        [HttpGet]
        public IActionResult FiltroReceta(int indice)
        {
            var receta = _baseDatos.Receta
                .Where(i => i.Idreceta == indice)
                .Select(pa => new
                {
                    pa.Idreceta,
                    pa.CodigoReceta,
                    pa.Medicamento,
                    pa.Indicaciones,
                    pa.Cantidad,
                    pa.Fecha,
                    pa.DuracionTratamiento,
                   

                })
                .ToList();
            if (receta.Count == 0)
            {
                return Json(new { success = false, message = "No se encontraron datos para el area proporcionada" });
            }
            else
            {
                return Json(new { success = true, datos = receta });
            }

        }

        [HttpGet]
        public async Task<IActionResult> AgregarReceta(int IDreceta)
        {
            RecetumVM receta = new RecetumVM()
            {
                obRecetum = new Recetum(),
                listaExpediente = await _baseDatos.Expedientes.Select(at => new SelectListItem()
                {
                    Text = at.NumeroExpediente,
                    Value = at.Idexpediente.ToString()

                }).ToListAsync()
            };


            if (IDreceta != 0)
            {
                receta.obRecetum = await _baseDatos.Receta.FindAsync(IDreceta);
            }
            

            return View(receta);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarReceta(RecetumVM recetum)
        {
            if (ModelState.IsValid)
            {
                if (recetum.obRecetum.Idreceta == 0)
                {

                    _baseDatos.Receta.Add(recetum.obRecetum);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeCrear"] = "El expediente se agrego correctamente";
                    return RedirectToAction(nameof(AgregarReceta));
                }
                else
                {

                    _baseDatos.Receta.Update(recetum.obRecetum);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeActualizar"] = "El usuario se actualizo correctamente";
                    return RedirectToAction(nameof(IndexReceta));
                }

            }

            TempData["Error"] = "¡Advertencia! Campos vacios";
            recetum = new RecetumVM()
            {
                obRecetum = new Recetum(),
                listaExpediente = await _baseDatos.Expedientes.Select(at => new SelectListItem()
                {
                    Text = at.NumeroExpediente,
                    Value = at.Idexpediente.ToString()

                }).ToListAsync()
            };


            return View(recetum);
        }


    }
}

    

