using System;
using System.Collections.Generic;

namespace Datos.Datos;

public partial class Sucursal
{
    public int Idsucursal { get; set; }

    public string? Nombresucursal { get; set; }

    public int? Idciudad { get; set; }

    public bool? Estadosucursal { get; set; }

    public virtual Ciudad? IdciudadNavigation { get; set; }
}
