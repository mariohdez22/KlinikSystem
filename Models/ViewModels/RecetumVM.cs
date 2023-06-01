using Microsoft.AspNetCore.Mvc.Rendering;
#pragma warning disable

namespace KlinikSystem.Models.ViewModels
{
    public class RecetumVM
    {
        public Recetum obRecetum { get; set; }
        public List<SelectListItem> listaRecetum { get; set; }
        public List<SelectListItem> listaExpediente { get; set; }
    }
}
