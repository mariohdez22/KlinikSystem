using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class MetodoPago
{
    public int IdmetodoPago { get; set; }

    public string? MetodoPago1 { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
