using System;
using System.Collections.Generic;

namespace Datos.Datos;

public partial class Persona
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Edad { get; set; }

    public string? Frase { get; set; }

    public bool? Estado { get; set; }
}
