using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class AreaTrabajo
{
    public int IdareaTrabajo { get; set; }

    public string AreaTrabajo1 { get; set; } = null!;

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();
}
