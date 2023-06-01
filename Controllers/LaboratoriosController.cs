using KlinikSystem.Models;
using KlinikSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
#pragma warning disable

namespace KlinikSystem.Controllers
{
    public class LaboratoriosController : Controller
    {
        private readonly KlinikSystemContext _baseDatos;

        public LaboratoriosController(KlinikSystemContext baseDatos) 
        {
            _baseDatos = baseDatos;
        }

        public IActionResult IndexLaboratorio()
        {
            List<LaboratorioVM> laboratorios = _baseDatos.Laboratorios.Include(de => de.DetalleExamen)
            .Select(l => new LaboratorioVM() 
            { 
                Idexpediente = l.Idexpediente,
                CodigoLaboratorio = l.CodigoLaboratorio,
                Subtotal = l.Subtotal,
                Total = l.Total,
                TipoSangre = l.TipoSangre,
                IdestadoLaboratorio = l.IdestadoLaboratorio,
                DetalleExamen = _baseDatos.DetalleExamen.Include(dd => dd.DetalleDatos)
                .Select(de => new DetalleExamenVM() 
                { 
                    CodigoDetalle = de.CodigoDetalle,
                    IdpruebaExamen = de.IdpruebaExamen,
                    Subtotal = de.Subtotal,
                    DetalleDatos = _baseDatos.DetalleDatos
                    .Select(dd => new DetalleDatosVM() 
                    { 
                        IddatoExamen = dd.IddatoExamen,
                        Precio = dd.Precio
                    
                    }).ToList()

                }).ToList()

            }).ToList();  

            return View();
        }

        //------------------------------------------------------------------------------

        public IActionResult buscarDatoExamen(int busqueda)
        {
            LaboratorioVM datoExamen = new LaboratorioVM() 
            { 
                datoExamens = _baseDatos.DatoExamen
                .Where(b => b.IdpruebaExamen == busqueda)
                .Select(d => new DatoExamenVM() 
                { 
                
                    IddatoExamen = d.IddatoExamen,
                    Dato = d.Dato,
                    IdpruebaExamen = d.IdpruebaExamen,
                    PruebaExamen = d.IdpruebaExamenNavigation.NombrePrueba

                }).ToList()
            };

            return Json(new { datos = datoExamen });
        }

        [HttpGet]
        public IActionResult AgregarLaboratorio() 
        {
            LaboratorioVM pruebaExamen = new LaboratorioVM()
            {
                pruebaExamens = _baseDatos.PruebaExamen
                .Select(p => new PruebaExamenVM() 
                { 
                
                    IdpruebaExamen = p.IdpruebaExamen,
                    NombrePrueba = p.NombrePrueba,
                    Precio = p.Precio,
                    IdtipoExamen = p.IdtipoExamen,
                    TipoExamen = p.IdtipoExamenNavigation.TipoExamen

                }).ToList()
            };

            return View(pruebaExamen);
        }

        [HttpPost]
        public IActionResult AgregarLaboratorio(LaboratorioVM oLabVM)
        {
            try
            {
                Laboratorio laboratorio = new Laboratorio();
                laboratorio.Idexpediente = oLabVM.Idexpediente;
                laboratorio.CodigoLaboratorio = oLabVM.CodigoLaboratorio;
                laboratorio.Subtotal = oLabVM.Subtotal;
                laboratorio.Total = oLabVM.Total;
                laboratorio.Fecha = DateTime.Now;
                laboratorio.TipoSangre = oLabVM.TipoSangre;
                laboratorio.IdestadoLaboratorio = oLabVM.IdestadoLaboratorio;

                _baseDatos.Add(laboratorio);
                _baseDatos.SaveChanges();

                foreach (var dev in oLabVM.DetalleExamen)
                {
                    DetalleExaman detalle = new DetalleExaman();
                    detalle.CodigoDetalle = dev.CodigoDetalle;
                    detalle.Idlaboratorio = laboratorio.Idlaboratorio;
                    detalle.IdpruebaExamen = dev.IdpruebaExamen;
                    detalle.Subtotal = dev.Subtotal;

                    _baseDatos.DetalleExamen.Add(detalle);
                    _baseDatos.SaveChanges();

                    foreach (var ddv in dev.DetalleDatos)
                    {
                        DetalleDato dato = new DetalleDato();
                        dato.IddetalleExamen = detalle.IddetalleExamen;
                        dato.IddatoExamen = ddv.IddatoExamen;
                        dato.Precio = ddv.Precio;

                        _baseDatos.DetalleDatos.Add(dato);
                    }

                    _baseDatos.SaveChanges();

                }

                _baseDatos.SaveChanges();
                return RedirectToAction(nameof(AgregarLaboratorio));

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}
