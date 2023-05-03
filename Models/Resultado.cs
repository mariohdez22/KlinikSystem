using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class Resultado
{
    public int Idresultados { get; set; }

    public int IddetalleExamen { get; set; }

    public string Paciente { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string Observaciones { get; set; } = null!;

    public virtual ICollection<DetalleResultado> DetalleResultados { get; set; } = new List<DetalleResultado>();

    public virtual DetalleExaman IddetalleExamenNavigation { get; set; } = null!;
}
