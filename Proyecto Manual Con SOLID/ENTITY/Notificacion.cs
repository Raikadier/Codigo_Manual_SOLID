using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    // Esta clase solo se encarga de almacenar la información de la notificación (SRP).
    public class Notificacion
    {
        public int IdNotificacion { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
    }
}
