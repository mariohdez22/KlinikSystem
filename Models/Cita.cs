using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class Cita
{
    public int Idcitas { get; set; }

    public string NumCita { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public int Idpaciente { get; set; }

    public string DuiPaciente { get; set; } = null!;

    public int Idpersonal { get; set; }

    public string EspecialidadPersonal { get; set; } = null!;

    public int IdestadoCita { get; set; }

    public int IdmetodoPago { get; set; }

    public decimal Precio { get; set; }

    public virtual EstadoCitum IdestadoCitaNavigation { get; set; } = null!;

    public virtual MetodoPago IdmetodoPagoNavigation { get; set; } = null!;

    public virtual Paciente IdpacienteNavigation { get; set; } = null!;

    public virtual Personal IdpersonalNavigation { get; set; } = null!;
}
