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
    public class SectorController : Controller
    {
        private readonly ISector _inyeccion;
        public SectorController(ISector inyeccion)
        {
            this._inyeccion = inyeccion;
        }


        [HttpGet]
        public ActionResult GetPersonas()
        {
            try
            {
                return Ok(_inyeccion.GetSectores());
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return Ok();
            }
            
        }

    }
}
