using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class Laboratorio
{
    public int Idlaboratorio { get; set; }

    public int Idexpediente { get; set; }

    public string CodigoLaboratorio { get; set; } = null!;

    public decimal Subtotal { get; set; }

    public decimal Total { get; set; }

    public DateTime Fecha { get; set; }

    public string TipoSangre { get; set; } = null!;

    public int IdestadoLaboratorio { get; set; }

    public virtual ICollection<DetalleExaman> DetalleExamen { get; set; } = new List<DetalleExaman>();

    public virtual EstadoLaboratorio IdestadoLaboratorioNavigation { get; set; } = null!;

    public virtual Expediente IdexpedienteNavigation { get; set; } = null!;
}
