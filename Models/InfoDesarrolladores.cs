using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APISample.Models
{
    public partial class InfoDesarrolladores
    {
        public int IdDesarrollador { get; set; }
        
        public string Nombre { get; set; }
        
        public string Profesion { get; set; }
        
        public string Puesto { get; set; }
        
        public string Tecnologia { get; set; }   
    }
}
