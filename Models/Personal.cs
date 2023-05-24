using Microsoft.AspNetCore.Mvc.Rendering;   
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#pragma warning disable

namespace KlinikSystem.Models;

public partial class Personal
{
    [Key]
    public int Idpersonal { get; set; }

    [StringLength(50, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
    [Required(ErrorMessage = "Nombre obligatorio")]
    public string Nombres { get; set; } = null!;

    [StringLength(9, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 9)]
    [Required(ErrorMessage = "Dui Obligatorio")]
    public string Dui { get; set; } = null!;

    [StringLength(50, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 5)]
    [Required(ErrorMessage = "Profecion Obligatorio")]
    public string Profecion { get; set; } = null!;

    [StringLength(8, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 8)]
    [Required(ErrorMessage = "Celular Obligatorio")]
    public string Celular { get; set; } = null!;

    [StringLength(50, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 10)]
    [Required(ErrorMessage = "Correo Obligatorio")]
    public string Correo { get; set; } = null!;

    [StringLength(50, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 8)]
    [Required(ErrorMessage = "Contraseña Obligatorio")]
    public string Contrasena { get; set; } = null!;

    [StringLength(200, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
    [Required(ErrorMessage = "Imagen Obligatoria")]
    public string Imagen { get; set; } = null!;

    [Required]
    public int IdareaTrabajo { get; set; }

    [Required]
    public int Idespecialidad { get; set; }

    [Required]
    public int IdestadoPersonal { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();

    public virtual AreaTrabajo IdareaTrabajoNavigation { get; set; } = null!;

    public virtual Especialidade IdespecialidadNavigation { get; set; } = null!;

    public virtual EstadoPersonal IdestadoPersonalNavigation { get; set; } = null!;

}

