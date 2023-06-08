using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace KlinikSystem.Models;

public partial class Cita
{
    [Key]
    public int Idcitas { get; set; }

    [StringLength(9, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 9)]
    [Required(ErrorMessage = "Numero de cita obligatorio")]
    public string NumCita { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public int Idpaciente { get; set; }

    [StringLength(8, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 8)]
    [Required(ErrorMessage = "Dui Obligatorio")]
    public string DuiPaciente { get; set; } = null!;

    public int Idpersonal { get; set; }

    [StringLength(50, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
    [Required(ErrorMessage = "Especialidad obligatoria")]
    public string EspecialidadPersonal { get; set; } = null!;

    public int IdestadoCita { get; set; }

    public int IdmetodoPago { get; set; }

   
    [Required(ErrorMessage = "Precio Obligatorio")]
    public decimal Precio { get; set; }

    public virtual EstadoCitum IdestadoCitaNavigation { get; set; } = null!;

    public virtual MetodoPago IdmetodoPagoNavigation { get; set; } = null!;

    public virtual Paciente IdpacienteNavigation { get; set; } = null!;

    public virtual Personal IdpersonalNavigation { get; set; } = null!;
}
