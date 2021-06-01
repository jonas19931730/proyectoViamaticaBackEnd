using System.Globalization;
using ProyectoViamatica.DBContext;
using ProyectoViamatica.Interfaces;
using ProyectoViamatica.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoViamatica.Modal.Solicitud;

namespace ProyectoViamatica.Servicios
{
    public class PersonaServices : IPersona
    {
        private readonly Context _context;
        public PersonaServices(Context context)
        {
            this._context = context;
        }
        public IEnumerable<Object> GetPersonas()
        {
           
                var lst2 = _context.Personas

               .Select(p =>
               new
               {
                   p.Id,
                   p.Nombre,
                   p.FechaNacimiento,
                   p.Sueldo,
                   p.IdZonaNavigation.DescripcionZona,
                   p.IdZonaNavigation.IdSectorNavigation.DescripcionSector
               }
               ).ToList();
                return (IEnumerable<Object>)lst2;
            
           
     

        }
        public int GetId()
        {
            if (_context.Personas.Count() > 0)
            {
                int id = 0;
                var lst = _context.Personas.Select(p => p.Id).ToList();
                for(int i = 0; i < lst.Count(); i++)
                {
                    if (i == lst.Count() - 1)
                    {
                        id = lst.ElementAt(i);
                    }
                }
                return id;
            }
            else
            {
                return 1;
            }
                 
            
        }
        public void Post(PersonaSolicitud P)
        {
            Persona nuevo = new Persona
            {
                Nombre = P.Nombre,
                FechaNacimiento = P.FechaNacimiento,
                Sueldo = P.Sueldo,
                IdZona = P.IdZona
            };
            _context.Add(nuevo);
            _context.SaveChanges();

        }
        public void Put(PersonaModificar P)
        {
            Persona p = _context.Personas.Find(P.Id);

            p.Nombre = P.Nombre;
            p.FechaNacimiento = P.FechaNacimiento;
            p.Sueldo = P.Sueldo;
            p.IdZona = P.IdZona;
            _context.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
      

        public void Delete(PersonaModificar P)
        {
            Persona oPersona = _context.Personas.Find(P.Id);
            _context.Personas.Remove(oPersona);
            _context.SaveChanges();
        }

   
        IEnumerable<Object> IPersona.GetPersona(string nombre)
        {
            var lst = _context.Personas.Where(p => p.Nombre.Contains(nombre)).Select(p =>
                new
                {
                    p.Id,
                    p.Nombre,
                    p.FechaNacimiento,
                    p.Sueldo,
                    p.IdZonaNavigation.DescripcionZona,
                    p.IdZonaNavigation.IdSectorNavigation.DescripcionSector
                }
                ).ToList();
            return (IEnumerable<Object>)lst;
        }

       
    }
}
