using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class TipoServicio
{
    public int IdtipoServicio { get; set; }

    public string TipoServicio1 { get; set; } = null!;

    public virtual ICollection<DetalleServicio> DetalleServicios { get; set; } = new List<DetalleServicio>();
}
