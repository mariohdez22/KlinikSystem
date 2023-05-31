using Microsoft.AspNetCore.Mvc.Rendering;

namespace KlinikSystem.Models.ViewModels
{
    public class PacienteVM
    {
        public Paciente obPaciente { get; set; }

        public List<SelectListItem> listaEstadoPaciente { get; set; }
    }
}
