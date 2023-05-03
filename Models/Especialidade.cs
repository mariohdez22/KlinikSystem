using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class Especialidade
{
    public int Idespecialidad { get; set; }

    public string Especialidad { get; set; } = null!;

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();
}
