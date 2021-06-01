using Microsoft.AspNetCore.Mvc;
using ProyectoViamatica.DBContext;
using ProyectoViamatica.Interfaces;
using ProyectoViamatica.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoViamatica.Servicios
{
    public class ZonaServices : IZona
    {
        private readonly Context _context; 
        public ZonaServices(Context context)
        {
            this._context = context;
        }
        public List<Zona> GetZonas(int id)
        {
            var lst = _context.Zonas.Where(z => z.IdSector == id).Select(z => z).ToList();
            return lst;
        }
    }
}
