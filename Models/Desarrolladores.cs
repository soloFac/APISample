using System;
using System.Collections.Generic;

#nullable disable

namespace APISample.Models
{
    public partial class Desarrolladores
    {
        public int IdDesarrollador { get; set; }
        public string Nombre { get; set; }
        public string Profesion { get; set; }
        public int IdPuesto { get; set; }
        public int IdTecnologia { get; set; }

        public virtual Puestos IdPuestoNavigation { get; set; }
        public virtual Tecnologias IdTecnologiaNavigation { get; set; }
    }
}
