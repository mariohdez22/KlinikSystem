using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class Servicio
{
    public int Idservicios { get; set; }

    public int Idexpediente { get; set; }

    public string CodigoServicio { get; set; } = null!;

    public decimal Subtotal { get; set; }

    public decimal Total { get; set; }

    public DateTime Fecha { get; set; }

    public virtual ICollection<DetalleServicio> DetalleServicios { get; set; } = new List<DetalleServicio>();

    public virtual Expediente IdexpedienteNavigation { get; set; } = null!;
}
