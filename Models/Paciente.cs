using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace KlinikSystem.Models;

public partial class Paciente
{
    [Key]
    public int Idpaciente { get; set; }

    [StringLength(50, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
    [Required(ErrorMessage = "Nombre obligatorio")]
    public string Nombre { get; set; } = null!;

    [StringLength(9, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 9)]
    [Required(ErrorMessage = "Dui Obligatorio")]
    public string Dui { get; set; } = null!;

    [StringLength(50, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 10)]
    [Required(ErrorMessage = "Correo Obligatorio")]
    public string Correo { get; set; } = null!;

    [StringLength(8, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 8)]
    [Required(ErrorMessage = "Celular Obligatorio")]
    public string Celular { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }


    [StringLength(50, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 8)]
    [Required(ErrorMessage = "Contraseña Obligatorio")]
    public string Contrasena { get; set; } = null!;

    public int IdestadoPaciente { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();

    

    public virtual EstadoPaciente IdestadoPacienteNavigation { get; set; } = null!;
}
