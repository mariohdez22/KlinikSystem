using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class TipoExaman
{
    public int IdtipoExamen { get; set; }

    public string TipoExamen { get; set; } = null!;

    public virtual ICollection<PruebaExaman> PruebaExamen { get; set; } = new List<PruebaExaman>();
}
