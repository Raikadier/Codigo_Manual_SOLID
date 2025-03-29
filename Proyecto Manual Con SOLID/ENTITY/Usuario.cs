using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    // Clase Usuario abstracta para obligar a cada derivado a definir su rol (SRP).
    //Tambien se aplica OCP ya que se puede extender la clase sin modificarla.
    public abstract class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public abstract string Rol { get; }
    }
}
