using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class Recetum
{
    public int Idreceta { get; set; }

    public int Idexpediente { get; set; }

    public string CodigoReceta { get; set; } = null!;

    public string Medicamento { get; set; } = null!;

    public string Indicaciones { get; set; } = null!;

    public int Cantidad { get; set; }

    public DateTime Fecha { get; set; }

    public string DuracionTratamiento { get; set; } = null!;

    public virtual Expediente IdexpedienteNavigation { get; set; } = null!;
}
