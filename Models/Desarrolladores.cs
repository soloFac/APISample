using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace APISample.Models
{
    public partial class Desarrolladores
    {
        public int IdDesarrollador { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Profesion { get; set; }
        [Required]
        public int IdPuesto { get; set; }
        [Required]
        public int IdTecnologia { get; set; }

        public virtual Puestos IdPuestoNavigation { get; set; }
        public virtual Tecnologias IdTecnologiaNavigation { get; set; }
    }
}
