using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class Unidade
{
    public int Idunidades { get; set; }

    public string Unidad { get; set; } = null!;

    public virtual ICollection<DetalleResultado> DetalleResultados { get; set; } = new List<DetalleResultado>();
}
