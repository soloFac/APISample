using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace APISample.Models
{
    public partial class Tecnologias
    {
        public Tecnologias()
        {
            Desarrolladores = new HashSet<Desarrolladores>();
        }

        public int IdTecnologia { get; set; }
        [Required]
        public string Tecnologia { get; set; }

        public virtual ICollection<Desarrolladores> Desarrolladores { get; set; }
    }
}
