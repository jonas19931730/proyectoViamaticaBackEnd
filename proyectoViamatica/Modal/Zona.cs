using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoViamatica.Modal
{
    public class Zona
    {
        
        public int IdZona { get; set; }
        public string DescripcionZona { get; set; }
        public int IdSector { get; set; }
        public virtual Sector IdSectorNavigation { get; set; }
        public virtual List<Persona> Persona { get; set; }
    }
}
