using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class EstadoPaciente
{
    public int IdestadoPaciente { get; set; }

    public string EstadoPaciente1 { get; set; } = null!;

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
