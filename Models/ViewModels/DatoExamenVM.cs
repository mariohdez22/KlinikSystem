namespace KlinikSystem.Models.ViewModels
{
    public class DatoExamenVM
    {
        public int IddatoExamen { get; set; }

        public string Dato { get; set; } = null!;

        public int IdpruebaExamen { get; set; }

        public string PruebaExamen { get; set; }
    }
}
