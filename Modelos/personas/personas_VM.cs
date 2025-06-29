using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.personas
{
    public class personas_VM
    {

        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public int? Edad { get; set; }

        public string? Frase { get; set; }

        public bool? Estado { get; set; }
    }
}
