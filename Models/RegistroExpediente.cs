using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class RegistroExpediente
{
    public int IdregistroExpediente { get; set; }

    public int Idexpediente { get; set; }

    public string MotivoVisita { get; set; } = null!;

    public string Sintomas { get; set; } = null!;

    public string GravedadAsunto { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public virtual Expediente IdexpedienteNavigation { get; set; } = null!;
}
