using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class EstadoExpediente
{
    public int IdestadoExpediente { get; set; }

    public string EstadoExpediente1 { get; set; } = null!;

    public virtual ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();
}
