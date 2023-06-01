using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class DetalleDato
{
    public int IddetalleDatos { get; set; }

    public int IddetalleExamen { get; set; }

    public int IddatoExamen { get; set; }

    public decimal Precio { get; set; }

    public virtual DatoExaman IddatoExamenNavigation { get; set; } = null!;

    public virtual DetalleExaman IddetalleExamenNavigation { get; set; } = null!;

}
