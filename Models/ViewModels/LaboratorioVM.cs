#pragma warning disable

namespace KlinikSystem.Models.ViewModels
{
    public class LaboratorioVM
    {
        public int Idexpediente { get; set; }

        public string CodigoLaboratorio { get; set; } = null!;

        public decimal Subtotal { get; set; }

        public decimal Total { get; set; }

        public string TipoSangre { get; set; } = null!;

        public int IdestadoLaboratorio { get; set; }

        public List<DetalleExamenVM> DetalleExamen { get; set; }

        //--------------------------------------------------------

        public List<PruebaExamenVM> pruebaExamens { get; set; }

        public List<DatoExamenVM> datoExamens { get; set; }

    }
}
