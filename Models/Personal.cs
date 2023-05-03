using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class Personal
{
    public int Idpersonal { get; set; }

    public string Nombres { get; set; } = null!;

    public string Dui { get; set; } = null!;

    public string Profecion { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string Imagen { get; set; } = null!;

    public int IdareaTrabajo { get; set; }

    public int Idespecialidad { get; set; }

    public int IdestadoPersonal { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();

    public virtual AreaTrabajo IdareaTrabajoNavigation { get; set; } = null!;

    public virtual Especialidade IdespecialidadNavigation { get; set; } = null!;

    public virtual EstadoPersonal IdestadoPersonalNavigation { get; set; } = null!;
}
