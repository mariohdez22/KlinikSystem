using Microsoft.AspNetCore.Mvc.Rendering;

namespace KlinikSystem.Models.ViewModels
#pragma warning disable

{
    public class RegistroExpedienteVM
    {
        public RegistroExpediente obRegistroExpediente { get; set; }
        public List<SelectListItem> listaRegistroExpediente { get; set; }
    }
}
