using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoViamatica.Modal
{


    public class Persona
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string FechaNacimiento { get; set; }
        public int Sueldo { get; set; }
        public int IdZona { get; set; }
        public virtual Zona IdZonaNavigation { get; set; }


    }
}
