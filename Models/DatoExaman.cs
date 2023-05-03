using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class DatoExaman
{
    public int IddatoExamen { get; set; }

    public string Dato { get; set; } = null!;

    public int IdpruebaExamen { get; set; }

    public virtual ICollection<DetalleDato> DetalleDatos { get; set; } = new List<DetalleDato>();

    public virtual ICollection<DetalleResultado> DetalleResultados { get; set; } = new List<DetalleResultado>();

    public virtual PruebaExaman IdpruebaExamenNavigation { get; set; } = null!;
}
