using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KlinikSystem.Models;

public partial class RegistroExpediente
{
    [Key]
    public int IdregistroExpediente { get; set; }

    [Required]
    public int Idexpediente { get; set; }

    [StringLength(50, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
    [Required(ErrorMessage = "Motivo visita obligatorio")]
    public string MotivoVisita { get; set; } = null!;

    [StringLength(50, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
    [Required(ErrorMessage = "Sintomas obligatorio")]
    public string Sintomas { get; set; } = null!;

    [StringLength(50, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
    [Required(ErrorMessage = "Gravedad Asunto Obligatorio")]
    public string GravedadAsunto { get; set; } = null!;

    [StringLength(15, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
    [Required(ErrorMessage = "Fecha Obligatorio")]
    public DateTime Fecha { get; set; }

    public virtual Expediente IdexpedienteNavigation { get; set; } = null!;
}
