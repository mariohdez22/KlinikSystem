using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class Paciente
{
    public int Idpaciente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Dui { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string Contrasena { get; set; } = null!;

    public int IdestadoPaciente { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();

    public virtual EstadoPaciente IdestadoPacienteNavigation { get; set; } = null!;
}
