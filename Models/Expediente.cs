using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#pragma warning disable


namespace KlinikSystem.Models;

public partial class Expediente
{
    [Key]
    public int Idexpediente { get; set; }

    [StringLength(10, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 4)]
    [Required(ErrorMessage = "Numero de expediete obligatorio")]
    public string NumeroExpediente { get; set; } = null!;

    [Required]
    public int Idpaciente { get; set; } 

    [Required]
    public int Idpersonal { get; set; } 

    [StringLength(8, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 8)]
    [Required(ErrorMessage = "Fecha de creacion obligatorio")]
    public DateTime FechaCreacion { get; set; } 

    [StringLength(25, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
    [Required(ErrorMessage = "Campo de alergia obligatorio")]
    public string Alergias { get; set; } = null!;

    [Required]
    public int IdestadoExpediente { get; set; }

    public virtual EstadoExpediente IdestadoExpedienteNavigation { get; set; } = null!;

    public virtual Paciente IdpacienteNavigation { get; set; } = null!;

    public virtual Personal IdpersonalNavigation { get; set; } = null!;

    public virtual ICollection<Laboratorio> Laboratorios { get; set; } = new List<Laboratorio>();

    public virtual ICollection<Recetum> Receta { get; set; } = new List<Recetum>();

    public virtual ICollection<RegistroExpediente> RegistroExpedientes { get; set; } = new List<RegistroExpediente>();

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
