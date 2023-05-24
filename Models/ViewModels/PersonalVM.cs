using Microsoft.AspNetCore.Mvc.Rendering;
#pragma warning disable

namespace KlinikSystem.Models.ViewModels
{
    public class PersonalVM
    {
        public Personal obPersonal { get; set; }

        public List<SelectListItem> listaAreaTrabajo { get; set; }

        public List<SelectListItem> listaEspecialidad { get; set; }

        public List<SelectListItem> listaEstadoPersonal { get; set; }

    }
}
