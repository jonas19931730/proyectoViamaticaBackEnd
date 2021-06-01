
using ProyectoViamatica.Modal;
using ProyectoViamatica.Modal.Solicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoViamatica.Interfaces
{
    public interface IPersona
    {
        public IEnumerable<Object> GetPersonas();
        public int GetId();
        public IEnumerable<Object> GetPersona(string nombre);
        public void Post(PersonaSolicitud p);
        public void Put(PersonaModificar p);
         public void Delete(PersonaModificar p);

    }
}
