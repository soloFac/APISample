using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace APISample.Models
{
    public partial class Puestos
    {
        public Puestos()
        {
            Desarrolladores = new HashSet<Desarrolladores>();
        }

        public int IdPuesto { get; set; }
        [Required]
        public string Puesto { get; set; }

        public virtual ICollection<Desarrolladores> Desarrolladores { get; set; }
    }
}
