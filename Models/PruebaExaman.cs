using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class PruebaExaman
{
    public int IdpruebaExamen { get; set; }

    public string NombrePrueba { get; set; } = null!;

    public decimal Precio { get; set; }

    public int IdtipoExamen { get; set; }

    public virtual ICollection<DatoExaman> DatoExamen { get; set; } = new List<DatoExaman>();

    public virtual ICollection<DetalleExaman> DetalleExamen { get; set; } = new List<DetalleExaman>();

    public virtual TipoExaman IdtipoExamenNavigation { get; set; } = null!;
}
