using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class DetalleExaman
{
    public int IddetalleExamen { get; set; }

    public string CodigoDetalle { get; set; } = null!;

    public int Idlaboratorio { get; set; }

    public int IdpruebaExamen { get; set; }

    public decimal Subtotal { get; set; }

    public virtual ICollection<DetalleDato> DetalleDatos { get; set; } = new List<DetalleDato>();

    public virtual Laboratorio IdlaboratorioNavigation { get; set; } = null!;

    public virtual PruebaExaman IdpruebaExamenNavigation { get; set; } = null!;

    public virtual ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();
}
