using System;
using System.Collections.Generic;

namespace KlinikSystem.Models;

public partial class DetalleResultado
{
    public int IddetalleResultados { get; set; }

    public int Idresultados { get; set; }

    public int IddatosExamen { get; set; }

    public string Resultado { get; set; } = null!;

    public int Idunidades { get; set; }

    public string RangoReferencia { get; set; } = null!;

    public virtual DatoExaman IddatosExamenNavigation { get; set; } = null!;

    public virtual Resultado IdresultadosNavigation { get; set; } = null!;

    public virtual Unidade IdunidadesNavigation { get; set; } = null!;
}
