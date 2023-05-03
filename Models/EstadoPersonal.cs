using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class EstadoPersonal
{
    public int IdestadoPersonal { get; set; }

    public string EstadoPersonal1 { get; set; } = null!;

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();
}
