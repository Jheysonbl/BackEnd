using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Back_prueba.Models;

public partial class Sucursal092023
{
    [Key]
    public int Codigo { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Identificacion { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public int? CodigoMoneda { get; set; }

    public bool? EsBorrado { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Moneda092023? CodigoMonedaNavigation { get; set; }
}
