using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KlinikSystem.Models;

public partial class Recetum
{
    [Key]
    public int Idreceta { get; set; }

    
    public int Idexpediente { get; set; }

    [StringLength(6, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 6)]
    [Required(ErrorMessage = "Codigo de receta obligatorio")]
    public string CodigoReceta { get; set; } = null!;

    [StringLength(50, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 4)]
    [Required(ErrorMessage = "Medicamento obligatorio")]
    public string Medicamento { get; set; } = null!;

    [StringLength(50, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 4)]
    [Required(ErrorMessage = "Indicaciones obligatorias")]
    public string Indicaciones { get; set; } = null!;

    [Required(ErrorMessage = "Cantidad obligatoria")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "Fecha Obligatoria")]
    public DateTime Fecha { get; set; }

    [StringLength(50, ErrorMessage = "El {0} debe de ser de al menos {2} y maximo {1} caracteres", MinimumLength = 4)]
    [Required(ErrorMessage = "Duracion de Tratamiento obligatorio")]
    public string DuracionTratamiento { get; set; } = null!;

    public virtual Expediente IdexpedienteNavigation { get; set; } = null!;
}
