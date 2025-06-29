using System;
using System.Collections.Generic;

namespace Datos.Datos;

public partial class Ciudad
{
    public int Idciudad { get; set; }

    public string? Nombreciudad { get; set; }

    public bool? Estadociudad { get; set; }

    public virtual ICollection<Sucursal> Sucursal { get; set; } = new List<Sucursal>();
}
