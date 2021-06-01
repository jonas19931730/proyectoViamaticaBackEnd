using Microsoft.AspNetCore.Mvc;
using ProyectoViamatica.Interfaces;
using ProyectoViamatica.Modal;
using ProyectoViamatica.Modal.Solicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoViamatica.Controllers
{

    [Route("api/[controller]")]

    [ApiController]
    [Route("api/[Controller]/codigo")]
    public class PersonaController : Controller
    {
        private readonly IPersona _inyeccion;
        public PersonaController(IPersona inyeccion)
        {
           
            this._inyeccion = inyeccion;
        }


        [HttpGet]
        public ActionResult GetPersonas()
        {
            try
            {
                return Ok(_inyeccion.GetPersonas());
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return Ok();
            }
            
        }


        [HttpGet("{id}")]
        public ActionResult GetId()
        {
            try
            {
                return Ok(_inyeccion.GetId());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Ok();
            }
                
           
           
        }
        
        [HttpGet("busqueda/{nombre}")]
        public ActionResult GetNombre(string nombre)
        {
            try
            {
                if (nombre.Equals("-1"))
                {
                    return Ok(_inyeccion.GetPersonas());
                }

                else
                {
                    return Ok(_inyeccion.GetPersona(nombre));
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return Ok();
                
            }
           
        }
        [HttpPost]
        public ActionResult Post([FromBody]PersonaSolicitud P)
        {
            try
            {
                _inyeccion.Post(P);
                return Ok();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return Ok();

            }
           
        }
        
        [HttpPut]
        public ActionResult Put([FromBody]PersonaModificar P)
        {
            try
            {
                _inyeccion.Put(P);
                return Ok();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return Ok();
            }
           
        }
        
        [HttpDelete]
        public ActionResult Delete([FromBody] PersonaModificar P)
        {
            try
            {
                _inyeccion.Delete(P);
                return Ok();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return Ok();
            }
           
        }




    }
}
