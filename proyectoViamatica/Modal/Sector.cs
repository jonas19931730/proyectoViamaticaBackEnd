using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoViamatica.Modal
{
    public class Sector
    {
        [Key]
        public int IdSector { get; set; }
        public string DescripcionSector { get; set; }
        public virtual List<Zona> Zona { get; set; }
    }
}
