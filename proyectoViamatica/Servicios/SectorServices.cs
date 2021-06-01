using ProyectoViamatica.DBContext;
using ProyectoViamatica.Interfaces;
using ProyectoViamatica.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoViamatica.Servicios
{
    public class SectorServices : ISector
    {
        private readonly Context _context;
        public SectorServices(Context context)
        {
            this._context = context;
        }
        public IEnumerable<Sector> GetSectores()
        {
            var lst = _context.Sectores.Select(s => s).ToList();
            return lst;
        }
    }
}
