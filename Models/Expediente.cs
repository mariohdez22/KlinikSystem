using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class Expediente
{
    public int Idexpediente { get; set; }

    public string NumeroExpediente { get; set; } = null!;

    public int Idpaciente { get; set; }

    public int Idpersonal { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string Alergias { get; set; } = null!;

    public int IdestadoExpediente { get; set; }

    public virtual EstadoExpediente IdestadoExpedienteNavigation { get; set; } = null!;

    public virtual Paciente IdpacienteNavigation { get; set; } = null!;

    public virtual Personal IdpersonalNavigation { get; set; } = null!;

    public virtual ICollection<Laboratorio> Laboratorios { get; set; } = new List<Laboratorio>();

    public virtual ICollection<Recetum> Receta { get; set; } = new List<Recetum>();

    public virtual ICollection<RegistroExpediente> RegistroExpedientes { get; set; } = new List<RegistroExpediente>();

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
