using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class EstadoCitum
{
    public int IdestadoCita { get; set; }

    public string EstadoCita { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
