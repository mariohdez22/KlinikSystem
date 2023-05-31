
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KlinikSystem.Models.ViewModels
{
    public class CitasVM 
    {
        public Cita obCitas { get; set; }

        public List<SelectListItem> listaPaciente { get; set; }

        public List<SelectListItem> listaPersonal { get; set; }

        public List<SelectListItem> listaEstadoCitas { get; set; }

        public List<SelectListItem> listaMetodoPago { get; set; }
    }
}
