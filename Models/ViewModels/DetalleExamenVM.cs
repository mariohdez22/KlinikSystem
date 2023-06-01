#pragma warning disable

namespace KlinikSystem.Models.ViewModels
{
    public class DetalleExamenVM
    {
        public string CodigoDetalle { get; set; } = null!;

        public int IdpruebaExamen { get; set; }

        public decimal Subtotal { get; set; }

        public List<DetalleDatosVM> DetalleDatos { get; set; }
    }
}
