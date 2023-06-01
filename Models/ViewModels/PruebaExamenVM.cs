namespace KlinikSystem.Models.ViewModels
{
    public class PruebaExamenVM
    {
        public int IdpruebaExamen { get; set; }

        public string NombrePrueba { get; set; } = null!;

        public decimal Precio { get; set; }

        public int IdtipoExamen { get; set; }

        public string TipoExamen { get; set; }
    }
}
