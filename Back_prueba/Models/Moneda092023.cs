using System;
using System.Collections.Generic;

namespace Back_prueba.Models;

public partial class Moneda092023
{
    public int CodigoMoneda { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Sucursal092023> Sucursal092023s { get; set; } = new List<Sucursal092023>();
}
