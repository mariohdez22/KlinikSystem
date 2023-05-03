using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class EstadoLaboratorio
{
    public int IdestadoLaboratorio { get; set; }

    public string EstadoLaboratorio1 { get; set; } = null!;

    public virtual ICollection<Laboratorio> Laboratorios { get; set; } = new List<Laboratorio>();
}
