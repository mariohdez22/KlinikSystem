using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class DetalleServicio
{
    public int IddetalleServicios { get; set; }

    public int Idservicios { get; set; }

    public int IdtipoServicio { get; set; }

    public decimal Precio { get; set; }

    public string Resultado { get; set; } = null!;

    public virtual Servicio IdserviciosNavigation { get; set; } = null!;

    public virtual TipoServicio IdtipoServicioNavigation { get; set; } = null!;
}
