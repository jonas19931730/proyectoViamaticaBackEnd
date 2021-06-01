using Microsoft.AspNetCore.Mvc;
using ProyectoViamatica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoViamatica.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class ZonaController : Controller
    {
        private readonly IZona _inyeccion;
        public ZonaController(IZona inyeccion)
        {
            this._inyeccion = inyeccion;
        }


        [HttpGet("{id}")]
        public ActionResult GetZonas(int id)
        {
            try
            {
                return Ok(_inyeccion.GetZonas(id));
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return Ok();
                

            }
            
        }
    }
}
