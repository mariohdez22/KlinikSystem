using Microsoft.AspNetCore.Mvc.Rendering;
#pragma warning disable

namespace KlinikSystem.Models.ViewModels
{
    public class ExpedienteVM
    {
        public Expediente obExpediente { get; set; }    
        public List<SelectListItem> listaEstadoExpediente { get; set; }
        public List<SelectListItem> listaPaciente { get; set; }
        public List<SelectListItem> listaPersonal { get; set; }

    }
}
